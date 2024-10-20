using Application.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Paging
{
  public abstract class PagingRequest
  {
    public string? SearchText { get; set; } = string.Empty;
    [Range(0, int.MaxValue)]
    public int PageIndex { get; set; } = 0;
    [Range(1, 10)]
    public int PageSize { get; set; } = Constants.PAGE_SIZE;

  }
}
