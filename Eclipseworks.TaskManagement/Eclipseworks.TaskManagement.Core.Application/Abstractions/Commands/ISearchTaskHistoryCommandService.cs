using Eclipseworks.TaskManagement.Core.Domains.Domains.TaskHistories;

namespace Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands
{
    public interface ISearchTaskHistoryCommandService
    {
        Task<TaskHistory[]> SeachAllTaskHistories();
    }
}
