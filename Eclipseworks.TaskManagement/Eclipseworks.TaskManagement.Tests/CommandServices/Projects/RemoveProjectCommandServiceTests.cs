using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Remove;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects;
using Moq;

namespace Eclipseworks.TaskManagement.Tests.CommandServices.Projects
{
    public class RemoveProjectCommandServiceTests
    {
        [Fact]
        public async Task RemoveProject_ShouldRemoveProjectSuccessfully()
        {
            // Arrange
            var projectId = 1;

            var taskRepositoryMock = new Mock<ITaskRepository>();
            var projectUserRepositoryMock = new Mock<IProjectUserRepository>();
            var projectEntityWriteRepositoryMock = new Mock<IEntityWriteRepository<ProjectEntity>>();

            taskRepositoryMock.Setup(r => r.CountTasksByProjectId(projectId)).ReturnsAsync(0);
            projectUserRepositoryMock.Setup(r => r.DeleteProjectsByProjectId(projectId)).ReturnsAsync(true);
            projectEntityWriteRepositoryMock.Setup(r => r.Delete(It.IsAny<ProjectEntity>())).ReturnsAsync(true);

            var service = new RemoveProjectCommandService(
                projectEntityWriteRepositoryMock.Object,
                taskRepositoryMock.Object,
                projectUserRepositoryMock.Object);

            // Act
            var result = await service.RemoveProject(projectId);

            // Assert
            Assert.True(result.SuccesfullyDelete);
        }

        [Fact]
        public async Task RemoveProject_ShouldThrowException_WhenTasksArePending()
        {
            // Arrange
            var projectId = 1;

            var taskRepositoryMock = new Mock<ITaskRepository>();
            var projectUserRepositoryMock = new Mock<IProjectUserRepository>();
            var projectEntityWriteRepositoryMock = new Mock<IEntityWriteRepository<ProjectEntity>>();

            taskRepositoryMock.Setup(r => r.CountTasksByProjectId(projectId)).ReturnsAsync(1);

            var service = new RemoveProjectCommandService(
                projectEntityWriteRepositoryMock.Object,
                taskRepositoryMock.Object,
                projectUserRepositoryMock.Object);

            // Act & Assert
            await Assert.ThrowsAsync<Exception>(() => service.RemoveProject(projectId));
        }
    }
}
