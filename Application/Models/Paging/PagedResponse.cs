using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Paging
{
  public record PagedResponse<T>
  {
    public int TotalRows { get; init; }
    public List<T> Data { get; init; }

    public PagedResponse(int totalRows, List<T> data)
    {
      TotalRows = totalRows;
      Data = data;
    }
  }

  public record PagedResponseDto<T>
  {
    public int TotalRows { get; init; }
    public List<T>? Data { get; init; }
  }
}
