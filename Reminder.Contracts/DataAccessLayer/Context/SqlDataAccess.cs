using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using Dapper;
using System.Data;
using Reminder.Contracts.DataAccessLayer.Interfaces;

namespace Reminder.Contracts.DataAccessLayer.Context
{
    public class SqlDataAccess : ISqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Method for loading data from a database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parametrs"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parametrs, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parametrs, commandType: CommandType.StoredProcedure);
        }

        /// <summary>
        /// Method for storing data in the database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <param name="parametrs"></param>
        /// <param name="connectionId"></param>
        /// <returns></returns>
        public async Task SaveData<T>(string storedProcedure, T parametrs, string connectionId = "Default")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parametrs, commandType: CommandType.StoredProcedure);
        }
    }
}
