using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId.Responses;

namespace Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories
{
    public interface IProjectRepository
    {
        Task<ProjectSearchProjectsByUserIdResponse[]> SearchProjectsByUserId(int userId);
        Task<int> CountProjectsByTaskId(int projectId);
    }
}
