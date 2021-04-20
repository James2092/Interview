using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System;
using Microsoft.Extensions.Logging;
using System.Diagnostics.CodeAnalysis;

namespace Interview.Repository.DapperRepository
{
    [ExcludeFromCodeCoverage]
    public class DapperRepository : IRepository
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<DapperRepository> _logger;

        public DapperRepository(IConfiguration configuration, ILogger<DapperRepository> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public void ExecuteStoredProcedure(string name, object parameters)
        {
            using (var connection = new SqlConnection(_configuration.GetConnectionString("default")))
            {
                try
                {
                    if (connection.State == ConnectionState.Closed)
                        connection.Open();


                    connection.Query(name, parameters, commandType: CommandType.StoredProcedure);

                    _logger.LogInformation($"[DapperRepository] Successfully executed stored procedure {name}");
                }
                catch(Exception ex)
                {
                    _logger.LogError($"[DapperRepository] An error occured whilst executing stored procedure {name} with message {ex.Message}");
                    throw;
                }
                finally
                {
                    if(connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
    }
}
