using AutoMapper;
using Dapper;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Querys.SearchProjectsByUserId.Responses;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId.Responses;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Projects
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IMapper _mapper;
        private readonly DapperContext context;

        public ProjectRepository(DapperContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }

        public async Task<ProjectSearchProjectsByUserIdResponse[]> SearchProjectsByUserId(int userId)
        {
            try
            {
                using var db = context.CreateConnection();

                var query = $@"SELECT 
	                           projects.id as project_id, projects.name as projects_name, projects.description as projects_description,
	                           tasks.id as tasks_id, tasks.title as tasks_title, tasks.description as tasks_description, tasks.due_date as tasks_due_date, tasks.status as tasks_status, tasks.priority as tasks_priority,
	                           users.id as users_id, users.name as users_name, users.position as users_position
                           FROM projects
                           INNER JOIN project_user on project_user.project_id = projects.id
                           INNER JOIN users ON users.id = project_user.user_id 
                           LEFT JOIN tasks ON tasks.project_id = projects.id
                           WHERE users.id = {userId}";

                var extendedProjectEntity = await db.QueryAsync<ExtendedProjectEntity>(query);

                var project = BuildProject(extendedProjectEntity);
                return project;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CountProjectsByTaskId(int projectId)
        {
            try
            {
                using var db = context.CreateConnection();

                var query = $@"SELECT COUNT(1)
                           FROM tasks
                           WHERE project_id = {projectId};";

                var count = await db.ExecuteScalarAsync<int>(query, new { ProjectId = projectId });
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public ProjectSearchProjectsByUserIdResponse[] BuildProject(IEnumerable<ExtendedProjectEntity> extendedProjectEntities)
        {
            var extendedProjectEntitiesGrouped = extendedProjectEntities
                .GroupBy(e => e.project_id)
                .ToList();

            var projects = new List<ProjectSearchProjectsByUserIdResponse>();

            foreach (var extendedProjectEntity in extendedProjectEntitiesGrouped)
            {
                var projectEntity = extendedProjectEntity.First();
                var project = _mapper.Map<ProjectSearchProjectsByUserIdResponse>(projectEntity);

                var users = extendedProjectEntity
                    .GroupBy(e => e.users_id)
                    .Select(userGroup => _mapper.Map<UserSearchProjectsByUserIdResponse>(userGroup.First()))
                    .ToArray();

                var tasks = extendedProjectEntity
                    .GroupBy(e => e.tasks_id) 
                    .Select(taskGroup => _mapper.Map<TaskSearchProjectsByUserIdResponse>(taskGroup.First()))
                    .Where(q => q.Id != 0)
                    .ToArray();

                project.SetUsers(users);
                project.SetTasks(tasks);

                projects.Add(project);
            }

            return projects.ToArray();
        }
    }
}
