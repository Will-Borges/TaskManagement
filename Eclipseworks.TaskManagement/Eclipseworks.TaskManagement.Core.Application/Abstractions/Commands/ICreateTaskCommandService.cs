using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Responses;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface ICreateTaskCommandService
    {
        Task<CreateTaskResponse> CreateTask(CreateTaskRequestCommand command);
    }
}
