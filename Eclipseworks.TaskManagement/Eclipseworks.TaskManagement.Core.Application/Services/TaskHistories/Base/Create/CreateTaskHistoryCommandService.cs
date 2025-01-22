using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.TaskHistory;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create
{
    public class CreateTaskHistoryCommandService : ICreateTaskHistoryCommandService
    {
        private readonly IMapper _mapper;
        private readonly IEntityWriteRepository<TaskHistoryEntity> _taskHistoryEntityWriteRepository;
        private readonly IEntityReadRepository<TaskEntity> _taskEntityReadRepository;


        public CreateTaskHistoryCommandService(
            IMapper mapper,
            IEntityWriteRepository<TaskHistoryEntity> taskHistoryEntityWriteRepository,
            IEntityReadRepository<TaskEntity> taskEntityReadRepository)
        {
            _mapper = mapper;
            _taskHistoryEntityWriteRepository = taskHistoryEntityWriteRepository;
            _taskEntityReadRepository = taskEntityReadRepository;
        }


        public async Task CreateTaskHistory(CreateTaskHistoryRequestCommand command)
        {
            var task = await GetTaskById(command.Id);

            if (task.Id != 0)
            {
                var taskHistoryEntities = CheckChanges(task, command);

                if (taskHistoryEntities.Any())
                {
                    foreach (var entity in taskHistoryEntities)
                    {
                        await ExecuteCreateTaskHistory(entity);
                    }
                }
            }
        }

        private async Task ExecuteCreateTaskHistory(TaskHistoryEntity entity)
        {
            try
            {
                await _taskHistoryEntityWriteRepository.Create(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<TaskProject> GetTaskById(int taskId)
        {
            try
            {
                var taskEntity = await _taskEntityReadRepository.Get(taskId);

                if (taskEntity == null)
                    return new TaskProject();

                var task = _mapper.Map<TaskProject>(taskEntity);
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private TaskHistoryEntity[] CheckChanges(TaskProject task, CreateTaskHistoryRequestCommand command)
        {
            var taskHistoryEntities = new List<TaskHistoryEntity>();

            if (task.Title != command.Title)
            {
                taskHistoryEntities.Add(new TaskHistoryEntity(
                    task.Id,
                    "Title",
                    task.Title,
                    command.Title,
                    DateTime.UtcNow,
                    1 // add usuario que alterou
                ));
            }

            if (task.Description != command.Description)
            {
                taskHistoryEntities.Add(new TaskHistoryEntity(
                    task.Id,
                    "Description",
                    task.Description,
                    command.Description,
                    DateTime.UtcNow,
                    1
                ));
            }

            if (task.DueDate != command.DueDate)
            {
                taskHistoryEntities.Add(new TaskHistoryEntity(
                    task.Id,
                    "DueDate",
                    task.DueDate.ToString("yyyy-MM-dd"),
                    command.DueDate.ToString("yyyy-MM-dd"),
                    DateTime.UtcNow,
                    1
                ));
            }

            if (task.Status != command.Status)
            {
                taskHistoryEntities.Add(new TaskHistoryEntity(
                    task.Id,
                    "Status",
                    task.Status.ToString(),
                    command.Status.ToString(),
                    DateTime.UtcNow,
                    1
                ));
            }

            // Adicionar ProjectId 

            return taskHistoryEntities.ToArray();
        }
    }
}
