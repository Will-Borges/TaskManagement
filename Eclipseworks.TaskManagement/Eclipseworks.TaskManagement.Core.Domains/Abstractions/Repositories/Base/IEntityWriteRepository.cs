namespace Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base
{
    public interface IEntityWriteRepository<T>
    {
        Task<int> Create(T command);
        Task Create(T[] command);
        Task<bool> UpdateAsync(T command);
        Task<bool> Delete(T commandKey);
        Task<int> DeleteAllAsync(T[] command);
    }
}