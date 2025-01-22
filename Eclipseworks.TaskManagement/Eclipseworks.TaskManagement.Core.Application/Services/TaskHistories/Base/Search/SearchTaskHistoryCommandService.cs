using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Core.Domains.Domains.TaskHistories;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.TaskHistory;

namespace Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Search
{
    public class SearchTaskHistoryCommandService : ISearchTaskHistoryCommandService
    {
        private readonly IMapper _mapper;
        private readonly IEntityReadRepository<TaskHistoryEntity> _taskHistoryEntityReadRepository;


        public SearchTaskHistoryCommandService(
            IMapper mapper,
            IEntityReadRepository<TaskHistoryEntity> taskHistoryEntityReadRepository)
        {
            _mapper = mapper;
            _taskHistoryEntityReadRepository = taskHistoryEntityReadRepository;
        }


        public async Task<TaskHistory[]> SeachAllTaskHistories()
        {
            try
            {
                var taskEntity = await _taskHistoryEntityReadRepository.GetAll();

                var task = _mapper.Map<TaskHistory[]>(taskEntity);
                return task;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
