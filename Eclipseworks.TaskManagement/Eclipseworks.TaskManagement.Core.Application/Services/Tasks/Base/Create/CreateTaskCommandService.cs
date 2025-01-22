using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Responses;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create
{
    public class CreateTaskCommandService : ICreateTaskCommandService
    {
        private readonly IMapper _mapper;
        private readonly IEntityWriteRepository<TaskEntity> _taskEntityWriteRepository;
        private readonly IProjectRepository _projectRepository;


        public CreateTaskCommandService(
            IMapper mapper,
            IEntityWriteRepository<TaskEntity> taskEntityWriteRepository,
            IProjectRepository projectRepository)
        {
            _mapper = mapper;
            _taskEntityWriteRepository = taskEntityWriteRepository;
            _projectRepository = projectRepository;
        }


        public async Task<CreateTaskResponse> CreateTask(CreateTaskRequestCommand command)
        {
            var taskProject = _mapper.Map<TaskProject>(command);
            taskProject.Project.SetId(command.ProjectId);

            await CheckMaximumNumberTasks(taskProject);

            var taskEntity = _mapper.Map<TaskEntity>(command);
            return await ExecuteCreateTask(taskEntity);
        }

        public async Task CheckMaximumNumberTasks(TaskProject taskProject)
        {
            var count = await _projectRepository.CountProjectsByTaskId(taskProject.Id);

            if (count > 20)
            {
                throw new Exception("There are already 20 tasks associated with this project.");
            }
        }

        public async Task<CreateTaskResponse> ExecuteCreateTask(TaskEntity taskEntity)
        {
            try
            {
                var taskId = await _taskEntityWriteRepository.Create(taskEntity);

                var createTaskResponse = new CreateTaskResponse(taskId);
                return createTaskResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

