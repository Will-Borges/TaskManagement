using Eclipseworks.TaskManagement.Core.Domains.Querys.SearchProjectsByUserId.Responses;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SeachTasksByProjectId
{
    public interface ISeachTasksByProjectIdQuery
    {
        Task<SeachTasksByProjectIdQueryResponse[]> SeachTasksByProjectId(int projectId);
    }
}
