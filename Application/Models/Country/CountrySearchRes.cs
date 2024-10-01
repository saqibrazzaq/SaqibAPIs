using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Country
{
  public class CountrySearchRes
  {
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public int StateCount { get; set; }
  }
}
