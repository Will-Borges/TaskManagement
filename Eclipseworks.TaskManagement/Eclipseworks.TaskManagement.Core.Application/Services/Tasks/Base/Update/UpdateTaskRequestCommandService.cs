using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base;
using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Responses;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update
{
    public class UpdateTaskRequestCommandService : IUpdateTaskRequestCommandService
    {
        private readonly IMapper _mapper;
        private readonly IEntityWriteRepository<TaskUpdateEntity> _taskEntityWriteRepository;
        private readonly ICreateTaskHistoryCommandService _createTaskHistoryCommandService;


        public UpdateTaskRequestCommandService(
            IMapper mapper,
            IEntityWriteRepository<TaskUpdateEntity> taskEntityWriteRepository,
            ICreateTaskHistoryCommandService createTaskHistoryCommandService)
        {
            _mapper = mapper;
            _taskEntityWriteRepository = taskEntityWriteRepository;
            _createTaskHistoryCommandService = createTaskHistoryCommandService;
        }


        public async Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequestCommand command)
        {
            try
            {
                await CreateTaskHistory(command);

                var taskEntity = _mapper.Map<TaskUpdateEntity>(command);
                var succesfullyUpdate = await _taskEntityWriteRepository.UpdateAsync(taskEntity);

                var response = new UpdateTaskResponse(succesfullyUpdate);
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task CreateTaskHistory(UpdateTaskRequestCommand updateTaskCommand)
        {
            var taskHistoryCommand = _mapper.Map<CreateTaskHistoryRequestCommand>(updateTaskCommand);
            await _createTaskHistoryCommandService.CreateTaskHistory(taskHistoryCommand);
        }
    }
}
