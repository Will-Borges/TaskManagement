using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Remove.Responses;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Remove
{
    public class RemoveProjectCommandService : IRemoveProjectCommandService
    {
        private readonly IEntityWriteRepository<ProjectEntity> _projectEntityWriteRepository;
        private readonly IProjectUserRepository _projectUserRepository;
        private readonly ITaskRepository _taskRepository;


        public RemoveProjectCommandService(
            IEntityWriteRepository<ProjectEntity> projectEntityWriteRepository,
            ITaskRepository taskRepository,
            IProjectUserRepository projectUserRepository)
        {
            _projectEntityWriteRepository = projectEntityWriteRepository;
            _taskRepository = taskRepository;
            _projectUserRepository = projectUserRepository;
        }


        public async Task<RemoveProjectResponse> RemoveProject(int projectId)
        {
            await CheckIfExistTasksPendding(projectId);
            return await ExecuteRemove(projectId);
        }

        private async Task CheckIfExistTasksPendding(int projectId)
        {
            var count = await _taskRepository.CountTasksByProjectId(projectId);

            if (count > 0)
            {
                throw new Exception("There are still pending tasks, it was not possible to delete the project.");
            }
        }

        private async Task<RemoveProjectResponse> ExecuteRemove(int projectId)
        {
            try
            {
                var projectEntity = new ProjectEntity(projectId);

                var succesfullyDeleteProjectUser = await _projectUserRepository.DeleteProjectsByProjectId(projectId);
                var succesfullyDelete = await _projectEntityWriteRepository.Delete(projectEntity);

                var response = new RemoveProjectResponse();

                if (succesfullyDeleteProjectUser && succesfullyDelete)
                    response.SetSuccesfullyDelete(true);
                else
                    response.SetSuccesfullyDelete(false);

                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

