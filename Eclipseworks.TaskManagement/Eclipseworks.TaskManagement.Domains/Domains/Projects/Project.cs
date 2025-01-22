using Eclipseworks.TaskManagement.Domains.Domains.Users;

namespace Eclipseworks.TaskManagement.Domains.Domains.Projects
{
    public class Project
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public int TaskCount { get; private set; }
        public User[] User { get; private set; } = Array.Empty<User>();
        public Task[] Tasks { get; private set; } = Array.Empty<Task>();
        

        //Um projeto não pode ser removido com tarefas pendentes.
    }
}
