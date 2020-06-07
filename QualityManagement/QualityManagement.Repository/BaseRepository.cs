using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using QualityManagement.Repository.Util;
using QualityManagement.Frontier.Repository.Repositories;

namespace QualityManagement.Repository
{
    public class BaseRepository<TObject> : IBaseRepository<TObject>
    {
        private const int DEFAULT_TIMEOUT = 120;

        private readonly string _connectionString;

        public BaseRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<UObject> GetAsync<UObject>(string sql, object parameters, int? commandTimeout = null)
        {
            UObject returnObject;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;

                returnObject = await connection.QueryFirstOrDefaultAsync<UObject>(sql, parameters, commandTimeout: commandTimeout);
            }

            return returnObject != null ? DatabaseUtils.TrimStrings(new List<UObject>() { returnObject }).First() : default(UObject);
        }

        public async Task<IEnumerable<T>> ListAsync<T>(string sql, object parameters = null, int? commandTimeout = null)
        {
            IEnumerable<T> returnList;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;

                returnList = await connection.QueryAsync<T>(sql, parameters, commandTimeout: commandTimeout ?? DEFAULT_TIMEOUT);
            }

            return returnList != null ? DatabaseUtils.TrimStrings(returnList) : null;
        }

        public int Execute(string sql, object parameters, int? commandTimeout = null)
        {
            int executeCommandReturn;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.StatisticsEnabled = true;

                executeCommandReturn = connection.Execute(sql, parameters, commandTimeout: commandTimeout ?? DEFAULT_TIMEOUT);
            }

            return executeCommandReturn;
        }
    }
}
