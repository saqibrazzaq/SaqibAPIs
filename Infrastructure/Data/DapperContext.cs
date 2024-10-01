using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
  public class DapperContext
  {
    private readonly string _connectionString;
    private readonly IConfiguration _configuration;
    public DapperContext(IConfiguration configuration)
    {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("SqlServer") ?? "";
      if (string.IsNullOrEmpty(_connectionString))
      {
        throw new Exception("Sql Server Connection string not found");
      }
    }
    public IDbConnection CreateConnection()
        => new SqlConnection(_connectionString);
  }
}
