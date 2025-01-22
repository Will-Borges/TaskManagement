using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Remove;
using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Create;
using Eclipseworks.TaskManagement.Core.Application.Services.TaskHistories.Base.Search;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Remove;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Eclipseworks.TaskManagement.Core.Application.Ioc
{
    public static class ApplicationModuleExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<ICreateProjectCommandService, CreateProjectCommandService>();
            services.AddScoped<ICreateTaskCommandService, CreateTaskCommandService>();
            services.AddScoped<IUpdateTaskRequestCommandService, UpdateTaskRequestCommandService>();
            services.AddScoped<IRemoveTaskRequestCommandService, RemoveTaskRequestCommandService>();
            services.AddScoped<IRemoveProjectCommandService, RemoveProjectCommandService>();
            services.AddScoped<ICreateTaskHistoryCommandService, CreateTaskHistoryCommandService>();
            services.AddScoped<ISearchTaskHistoryCommandService, SearchTaskHistoryCommandService>();
           
            return services;
        }
    }
}
