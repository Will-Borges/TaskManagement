namespace Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories
{
    public interface IProjectUserRepository
    {
        Task<bool> DeleteProjectsByProjectId(int projectId);
    }
}
