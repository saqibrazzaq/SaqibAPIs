﻿using Application.Common;
using Application.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.State.Search
{
  public class StateSearchParams : PagingRequest
  {
    [JsonConverter(typeof(NullableIntConverter))]
    public int? CountryId { get; set; }
  }
}
