using System.Linq.Expressions;
using Dommel;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration;
using global::Dapper;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Default
{
    public class DapperReadRepository<T> : IEntityReadRepository<T>
        where T : class
    {
        private readonly DapperContext context;


        public DapperReadRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<T> Get(object id)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAsync<T>(id);
                return result;
            }
        }

        public async Task<T> Get(long code)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAsync<T>(code);
                return result;
            }
        }

        public async Task<T[]> GetAll()
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.GetAllAsync<T>();
                if (result != null && result.Any())
                {
                    return result.ToArray();
                }

                return Array.Empty<T>();
            }
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.AnyAsync<T>(predicate);
                return result;
            }
        }

        public async Task<T[]> QueryAsync(string query)
        {
            using (var db = context.CreateConnection())
            {
                var result = await db.QueryAsync<T>(query);
                if (result != null && result.Any())
                {
                    return result.ToArray();
                }

                return Array.Empty<T>();
            }
        }
    }
}
