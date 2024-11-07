using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.WebJobs.TextMessageSender
{
  public class TextMessageSenderParams
  {
    public string? Message { get; set; } = string.Empty;
  }
}
