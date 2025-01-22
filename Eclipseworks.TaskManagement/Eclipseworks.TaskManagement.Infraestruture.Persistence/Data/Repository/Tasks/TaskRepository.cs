using AutoMapper;
using Dapper;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Configuration;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Tasks
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IMapper _mapper;
        private readonly DapperContext context;


        public TaskRepository(DapperContext context, IMapper mapper)
        {
            this.context = context;
            _mapper = mapper;
        }


        public async Task<TaskProject[]> SeachTasksByProjectId(int projectId)
        {
            using var db = context.CreateConnection();

            var query = $@"SELECT T.ID, TITLE, T.DESCRIPTION, DUE_DATE, STATUS, PRIORITY
                           FROM TASKS AS T
                           INNER JOIN PROJECTS P ON P.ID = T.PROJECT_ID
                           WHERE P.ID = {projectId};";

            try
            {
                var resultEntity = await db.QueryAsync<TaskEntity>(query);

                var result = _mapper.Map<TaskProject[]>(resultEntity);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> CountTasksByProjectId(int projectId) 
        {
            using var db = context.CreateConnection();

            var query = $@"SELECT COUNT(1)
                           FROM tasks
                           WHERE project_id = {projectId} AND (STATUS = {(int)StatusTask.Pending} OR STATUS = {(int)StatusTask.Processing});";

            try
            {
                var count = await db.ExecuteScalarAsync<int>(query, new { ProjectId = projectId });
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
