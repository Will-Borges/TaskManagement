using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;

namespace Eclipseworks.TaskManagement.Domains.Domains.Users
{
    public class User
    {
        public string Name { get; private set; } = string.Empty;
        public string Position { get; private set; } = string.Empty;
        public Project[] Projects { get; private set; } = Array.Empty<Project>();
        public TaskProject[]? Tasks { get; private set; } = Array.Empty<TaskProject>();
    }
}
