using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Remove.Responses;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface IRemoveProjectCommandService
    {
        Task<RemoveProjectResponse> RemoveProject(int projectId);
    }
}
