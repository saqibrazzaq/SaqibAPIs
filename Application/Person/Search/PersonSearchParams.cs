using Application.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.Search
{
  public class PersonSearchParams : PagingRequest
  {
    public int? CountryId { get; set; }
    public int? StateId { get; set; }
  }
}
