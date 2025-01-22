using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Requests;
using Eclipseworks.TaskManagement.Core.Domains.Domains.TaskHistories;
using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Core.Domains.Querys.SearchProjectsByUserId.Responses;
using Eclipseworks.TaskManagement.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId.Responses;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.TaskHistory;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;

namespace Eclipseworks.TaskManagement.Automapper
{
    public class TaskManagementProfile : Profile
    {
        public TaskManagementProfile()
        {
            // Project

            CreateMap<ProjectEntity, Project>();
            CreateMap<Project, ProjectEntity>();

            CreateMap<CreateProjectRequestCommand, ProjectEntity>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            CreateMap<ExtendedProjectEntity, ProjectSearchProjectsByUserIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.project_id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.projects_name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.projects_description));

            CreateMap<ExtendedProjectEntity, UserSearchProjectsByUserIdResponse>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.users_name))
                .ForMember(dest => dest.Position, opt => opt.MapFrom(src => src.users_position));

            CreateMap<ExtendedProjectEntity, TaskSearchProjectsByUserIdResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.tasks_id))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.tasks_title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.tasks_description))
                .ForMember(dest => dest.DueDate, opt => opt.MapFrom(src => src.tasks_due_date))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => (StatusTask)src.tasks_status))  
                .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => (PriorityTask)src.tasks_priority));

            // Task

            CreateMap<CreateTaskRequestCommand, TaskProject>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProjectId));

            CreateMap<CreateTaskRequestCommand, TaskEntity>();
            CreateMap<UpdateTaskRequestCommand, TaskEntity>();

            CreateMap<TaskEntity, TaskProject>();

            CreateMap<TaskProject, SeachTasksByProjectIdQueryResponse>();

            CreateMap<UpdateTaskRequestCommand, TaskUpdateEntity>();

            // TaskHistory

            CreateMap<UpdateTaskRequestCommand, CreateTaskHistoryRequestCommand>();
            CreateMap<TaskHistoryEntity, TaskHistory>();
        }
    }
}
