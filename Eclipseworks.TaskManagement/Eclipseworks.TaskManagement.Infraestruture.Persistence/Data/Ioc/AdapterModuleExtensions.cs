using Eclipseworks.TaskManagement.Core.Application.Services.Projects.ListProjectsByUserId;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SeachTasksByProjectId;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Default;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Projects;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.ProjectUser;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Repository.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Ioc
{
    public static class AdapterModuleExtensions
    {
        public static IServiceCollection AddPersistenceRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IEntityReadRepository<>), typeof(DapperReadRepository<>));
            services.AddScoped(typeof(IEntityWriteRepository<>), typeof(DapperWriteRepository<>));

            // Repositories

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<IProjectUserRepository, ProjectUserRepository>();

            // Querys

            services.AddScoped<ISeachTasksByProjectIdQuery, SeachTasksByProjectIdQuery>();
            services.AddScoped<ISearchProjectsByUserIdQuery, SearchProjectsByUserIdQuery>();

            return services;
        }
    }
}
