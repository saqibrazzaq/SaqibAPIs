using Application.Common;
using Application.Models.Country;
using Application.Models.Paging;
using AutoMapper;
using Dapper;
using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Country.Search
{
  public class CountrySearchHandler
    : IRequestHandler<CountrySearchQuery, PagedResponseDto<CountrySearchRes>>
  {
    private readonly DapperContext _dapper;
    public CountrySearchHandler(DapperContext dapper)
    {
      _dapper = dapper;
    }

    public Task<PagedResponseDto<CountrySearchRes>> Handle(CountrySearchQuery request, CancellationToken cancellationToken)
    {
      request.req.SearchText = DapperUtility.encodeForLike(request.req.SearchText ?? "");

      var sqlCount = @"SELECT COUNT(*) FROM (
";
      var sqlRows = @"SELECT c.Id, c.Name, Code, Count(s.CountryId) AS stateCount
";
      var sqlCondition = @"FROM Country c
LEFT JOIN State s ON c.Id = s.CountryId WHERE 1=1 
";
      if (!string.IsNullOrEmpty(request.req.SearchText))
      {
        sqlCondition += @"AND (c.Name LIKE @SearchText OR c.Code LIKE @SearchText) ";
      }

      var sqlGroupBy = @"GROUP BY c.Id, c.Name, c.Code
";
      var sqlOrderBy = @"ORDER BY c.Name
";

      // Count query, without skip and fetch
      int totalRows = 0;
      using (var connection = _dapper.CreateConnection())
      {
        sqlCount += sqlRows + sqlCondition + sqlGroupBy + ") a";
        Console.WriteLine(sqlCount);
        totalRows = connection.ExecuteScalar<int>(sqlCount, request.req);
      }

      // Rows query with skip and fetch
      sqlRows += sqlCondition + sqlGroupBy + sqlOrderBy + @"OFFSET (@PageIndex * @PageSize) ROWS
FETCH NEXT @PageSize ROWS ONLY";

      Console.WriteLine(sqlRows);

      List<CountrySearchRes> entities;
      using (var connection = _dapper.CreateConnection())
      {
        entities = connection.Query<CountrySearchRes>(sqlRows, request.req).ToList();
      }

      var pagedRes = new PagedResponseDto<CountrySearchRes>()
      { Data = entities, TotalRows = totalRows };

      return Task.FromResult(pagedRes);
    }
  }
}
