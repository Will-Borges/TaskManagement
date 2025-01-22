using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create.Requests
{
    public class CreateTaskHistoryRequestCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public StatusTask Status { get; set; }
    }
}
