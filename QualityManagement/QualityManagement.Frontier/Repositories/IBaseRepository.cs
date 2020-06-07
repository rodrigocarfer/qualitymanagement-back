using System.Collections.Generic;
using System.Threading.Tasks;

namespace QualityManagement.Frontier.Repository.Repositories
{
    public interface IBaseRepository<TObject>
    {
        Task<UObject> GetAsync<UObject>(string sql, object parameters, int? commandTimeout = null);
        Task<IEnumerable<TObject>> ListAsync<TObject>(string sql, object parameters = null, int? commandTimeout = null);
        int Execute(string sql, object parameters, int? commandTimeout = null);
    }
}