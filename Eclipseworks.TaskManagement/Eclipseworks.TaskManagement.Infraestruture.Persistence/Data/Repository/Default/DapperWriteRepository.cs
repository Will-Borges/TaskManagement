using Dommel;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Default
{
    public class DapperWriteRepository<T> : IEntityWriteRepository<T>
        where T : class
    {
        private readonly DapperContext context;

        public DapperWriteRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<int> Create(T entity)
        {
            using var db = context.CreateConnection();

            var result = await db.InsertAsync(entity);
            return Convert.ToInt32(result);
        }

        public async Task Create(T[] entity)
        {
            using var db = context.CreateConnection();
            await db.InsertAllAsync(entity);
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            using var db = context.CreateConnection();
            var result = await db.UpdateAsync(entity);
            return result;
        }

        public async Task<bool> Delete(T entity)
        {
            using var db = context.CreateConnection();
            var result = await db.DeleteAsync(entity);
            return result;
        }

        public async Task<int> DeleteAllAsync(T[] entity)
        {
            using var db = context.CreateConnection();
            var result = await db.DeleteAllAsync<T>();
            return result;
        }
    }
}