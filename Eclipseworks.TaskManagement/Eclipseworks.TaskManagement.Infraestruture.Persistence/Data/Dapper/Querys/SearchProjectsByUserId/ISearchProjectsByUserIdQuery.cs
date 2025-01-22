using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId.Responses;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId
{
    public interface ISearchProjectsByUserIdQuery
    {
        Task<ProjectSearchProjectsByUserIdResponse[]> SearchProjectsByUserId(int userId);
    }
}
