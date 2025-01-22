using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Remove.Responses;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface IRemoveTaskRequestCommandService
    {
        Task<RemoveTaskResponse> RemoveTask(int taskId);
    }
}
