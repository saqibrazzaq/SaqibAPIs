using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common
{
  public static class DapperUtility
  {
    public static string encodeForLike(string value)
    {
      var res = value.Replace("[", "[[]").Replace("%", "[%]");
      return "%" + res + "%";
    }
  }
}
