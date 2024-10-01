﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.State
{
  public class StateRes
  {
    public int Id { get; set; }
    public string? Name { get; set; }

    public int? CountryId { get; set; }
  }
}
