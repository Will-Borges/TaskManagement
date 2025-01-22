using System.Linq.Expressions;

namespace Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base
{
    public interface IEntityReadRepository<T>
    {
        Task<T> Get(object id);
        Task<T[]> GetAll();
        Task<T[]> QueryAsync(string query);
        Task<T> Get(long id);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
    }
}