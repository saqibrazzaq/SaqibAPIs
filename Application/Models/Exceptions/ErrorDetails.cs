using System.Text.Json;

namespace Application.Models.Exceptions
{
  public class ErrorDetails
  {
    public ErrorDetails(int statusCode, string? message)
    {
      this.StatusCode = statusCode;
      this.Message = message;
    }
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public override string ToString() => JsonSerializer.Serialize(this);
  }
}
