using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;

namespace Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories
{
    public interface ITaskRepository
    {
        Task<TaskProject[]> SeachTasksByProjectId(int projectId);
        Task<int> CountTasksByProjectId(int projectId);
    }
}
