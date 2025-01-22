using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Core.Domains.Querys.SearchProjectsByUserId.Responses;
using Eclipseworks.TaskManagement.Domains.Domains.Users;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId.Responses
{
    public class ProjectSearchProjectsByUserIdResponse
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public UserSearchProjectsByUserIdResponse[] User { get; private set; } = Array.Empty<UserSearchProjectsByUserIdResponse>();
        public TaskSearchProjectsByUserIdResponse[] Tasks { get; private set; } = Array.Empty<TaskSearchProjectsByUserIdResponse>();

        public void SetUsers(UserSearchProjectsByUserIdResponse[] users)
        {
            User = users;
        }
        public void SetTasks(TaskSearchProjectsByUserIdResponse[] tasks)
        {
            Tasks = tasks;
        }
    }
}
