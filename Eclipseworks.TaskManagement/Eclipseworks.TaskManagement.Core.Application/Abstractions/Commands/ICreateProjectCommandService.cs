using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Results;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface ICreateProjectCommandService
    {
        Task<CreateProjectResponse> CreateProject(CreateProjectRequestCommand command);
    }
}
