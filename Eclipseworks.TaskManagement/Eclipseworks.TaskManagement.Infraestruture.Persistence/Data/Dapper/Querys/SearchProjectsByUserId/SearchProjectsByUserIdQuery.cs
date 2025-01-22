using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId.Responses;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Projects.ListProjectsByUserId
{
    public class SearchProjectsByUserIdQuery : ISearchProjectsByUserIdQuery
    {
        private readonly IProjectRepository _projectRepository;


        public SearchProjectsByUserIdQuery(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
    

        public async Task<ProjectSearchProjectsByUserIdResponse[]> SearchProjectsByUserId(int userId)
        {
            var projects = await _projectRepository.SearchProjectsByUserId(userId);
            return projects;
        }
    }
}
