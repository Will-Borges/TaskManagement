using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Remove.Responses;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Remove
{
    public class RemoveTaskRequestCommandService : IRemoveTaskRequestCommandService
    {
        private readonly IMapper _mapper;
        private readonly IEntityWriteRepository<TaskEntity> _taskEntityWriteRepository;


        public RemoveTaskRequestCommandService(
            IMapper mapper,
            IEntityWriteRepository<TaskEntity> taskEntityWriteRepository)
        {
            _mapper = mapper;
            _taskEntityWriteRepository = taskEntityWriteRepository;
        }


        public async Task<RemoveTaskResponse> RemoveTask(int taskId)
        {
            try
            {
                var entity = new TaskEntity(taskId);
                var succesfullyCreated = await _taskEntityWriteRepository.Delete(entity);

                var response = new RemoveTaskResponse(succesfullyCreated);
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while removing the task: {ex.Message}", ex);
            }
        }
    }
}
