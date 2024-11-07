using Microsoft.Azure.Functions.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.WebJobs
{
  public class TextMessageSenderRes
  {
    public string? Message { get; set; } = string.Empty;
  }
}
