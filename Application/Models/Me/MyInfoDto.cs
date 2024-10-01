using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Me
{
  public class MyInfoDto
  {
    public int UserId { get; set; }
    public string UserName { get; set; } = "saqibrazzaq@gmail.com";
    public string Name { get; set; } = "Saqib Razzaq";
    public bool ActiveFlag { get; set; } = true;
    public short OrganisationId { get; set; } = 1;
    public string OrganisationCode { get; set; } = "saqib";
    public string OrganisationName { get; set; } = "Saqib Organization";
  }
}
