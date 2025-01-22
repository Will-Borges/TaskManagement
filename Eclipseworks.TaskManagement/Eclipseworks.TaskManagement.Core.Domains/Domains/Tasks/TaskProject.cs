using Eclipseworks.TaskManagement.Domains.Domains.Tasks;

namespace Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks
{
    public class TaskProject
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public StatusTask Status { get; set; }
        public PriorityTask Priority { get; set; }
        public Project Project{ get; set; } = new Project();
    }
}
