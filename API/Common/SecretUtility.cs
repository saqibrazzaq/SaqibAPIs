namespace API.Common
{
  public class SecretUtility
  {
    public static string? APIKey => Environment.GetEnvironmentVariable("X_API_KEY");
  }
}
