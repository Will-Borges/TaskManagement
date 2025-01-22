using Dapper;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.ProjectUser
{
    public class ProjectUserRepository : IProjectUserRepository
    {
        private readonly DapperContext context;

        public ProjectUserRepository(DapperContext context)
        {
            this.context = context;
        }

        public async Task<bool> DeleteProjectsByProjectId(int projectId)
        {
            try
            {
                using var db = context.CreateConnection();

                var query = $@"DELETE FROM project_user
                               WHERE project_id = {projectId};";

                var rowsAffected = await db.ExecuteAsync(query);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception($"An error occurred while deleting records for ProjectId {projectId}: {ex.Message}");
            }
        }
    }
}
