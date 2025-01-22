using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Domains.Domains.Tasks;

namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Requests
{
    public class CreateTaskRequestCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; } 
        public StatusTask Status { get; set; }
        public PriorityTask Priority { get; set; }
        public int ProjectId { get; set; }
    }
}
