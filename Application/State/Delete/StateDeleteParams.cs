﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.State.Delete
{
  public class StateDeleteParams
  {
    [Required]
    public int Id { get; set; }
  }
}
