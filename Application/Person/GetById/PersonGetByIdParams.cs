using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Person.GetById
{
  public class PersonGetByIdParams
  {
    [Required]
    public int Id { get; set; }
  }
}
