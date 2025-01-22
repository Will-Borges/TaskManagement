using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Responses;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface IUpdateTaskRequestCommandService
    {
        Task<UpdateTaskResponse> UpdateTask(UpdateTaskRequestCommand command);
    }
}
