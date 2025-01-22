using Eclipseworks.TaskManagement.Domains.Domains.Users;

namespace Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks
{
    public class Project
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public User[] User { get; private set; } = Array.Empty<User>();
        public TaskProject[] Tasks { get; private set; } = Array.Empty<TaskProject>();

        public void SetId(int id)
        {
            Id = id;
        }
    }
}
