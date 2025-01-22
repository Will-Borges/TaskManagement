using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Requests
{
    public class UpdateTaskRequestCommand
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public StatusTask Status { get; set; }
        public int ProjectId{ get; set; }
    }
}
