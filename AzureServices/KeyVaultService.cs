using Azure.Security.KeyVault.Secrets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureServices
{
  public interface IKeyVaultService
  {
    Dictionary<string, string> GetAll();
  }
  public class KeyVaultService : IKeyVaultService
  {
    private readonly SecretClient _client;

    public KeyVaultService(SecretClient client)
    {
      _client = client;
    }

    public Dictionary<string, string> GetAll()
    {
      Dictionary<string, string> secretValues = new Dictionary<string, string>();
      IEnumerable<SecretProperties> secrets = _client.GetPropertiesOfSecrets();
      foreach (SecretProperties secret in secrets)
      {
        // Getting a disabled secret will fail, so skip disabled secrets.
        if (!secret.Enabled.GetValueOrDefault())
        {
          continue;
        }

        KeyVaultSecret secretWithValue = _client.GetSecret(secret.Name);
        if (secretValues.ContainsKey(secretWithValue.Value))
        {
          Debug.WriteLine($"Secret {secretWithValue.Name} shares a value with secret {secretValues[secretWithValue.Value]}");
        }
        else
        {
          secretValues.Add(secretWithValue.Value, secretWithValue.Name);
        }
      }

      return secretValues;
    }
  }
}
