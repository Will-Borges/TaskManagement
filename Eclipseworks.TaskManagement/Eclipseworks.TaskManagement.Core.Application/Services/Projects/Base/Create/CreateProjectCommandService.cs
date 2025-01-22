using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Results;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.ProjectUsers;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create
{
    public class CreateProjectCommandService : ICreateProjectCommandService
    {
        private readonly IMapper _mapper;
        private readonly IEntityWriteRepository<ProjectEntity> _projectEntityWriteRepository;
        private readonly IEntityWriteRepository<ProjectUserEntity> _projectUserEntityWriteRepository;


        public CreateProjectCommandService(
            IMapper mapper,
            IEntityWriteRepository<ProjectEntity> projectEntityWriteRepository,
            IEntityWriteRepository<ProjectUserEntity> projectUserEntityWriteRepository)
        {
            _projectEntityWriteRepository = projectEntityWriteRepository;
            _projectUserEntityWriteRepository = projectUserEntityWriteRepository;
            _mapper = mapper;
        }


        public async Task<CreateProjectResponse> CreateProject(CreateProjectRequestCommand command)
        {
            try
            {
                var projectEntity = _mapper.Map<ProjectEntity>(command);

                var projectId = await _projectEntityWriteRepository.Create(projectEntity);

                var projectUser = new ProjectUserEntity()
                {
                    ProjectId = projectId,
                    UserId = command.UserId
                };

                var projectUserId = await _projectUserEntityWriteRepository.Create(projectUser);

                var result = new CreateProjectResponse(projectId, projectUserId);

                return result;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }
    }
}
