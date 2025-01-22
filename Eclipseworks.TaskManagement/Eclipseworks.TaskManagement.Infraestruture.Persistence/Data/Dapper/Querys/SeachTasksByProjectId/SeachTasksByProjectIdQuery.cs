using AutoMapper;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Querys.SearchProjectsByUserId.Responses;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SeachTasksByProjectId
{
    public class SeachTasksByProjectIdQuery : ISeachTasksByProjectIdQuery
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;


        public SeachTasksByProjectIdQuery(
            IMapper mapper,
            ITaskRepository taskRepository)
        {
            _mapper = mapper;   
            _taskRepository = taskRepository;
        }


        public async Task<SeachTasksByProjectIdQueryResponse[]> SeachTasksByProjectId(int projectId)
        {
            var tasks = await _taskRepository.SeachTasksByProjectId(projectId);

            var result = _mapper.Map<SeachTasksByProjectIdQueryResponse[]>(tasks);
            return result;
        }
    }
}
