using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.GetById
{
    public class StateGetByIdParams
    {
        [Required]
        public int Id { get; set; }
    }
}
