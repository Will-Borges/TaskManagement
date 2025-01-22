using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create.Requests;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface ICreateTaskHistoryCommandService
    {
        Task CreateTaskHistory(CreateTaskHistoryRequestCommand command);
    }
}
