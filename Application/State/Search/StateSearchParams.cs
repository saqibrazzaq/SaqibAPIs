using Application.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.Search
{
  public class StateSearchParams : PagingRequest
  {
    public int? CountryId { get; set; }
  }
}
