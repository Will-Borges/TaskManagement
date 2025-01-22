using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects;
using Moq;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.ProjectUsers;

namespace Eclipseworks.TaskManagement.Tests.CommandServices.Projects
{
    public class CreateProjectCommandServiceTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IEntityWriteRepository<ProjectEntity>> _projectRepoMock = new();
        private readonly Mock<IEntityWriteRepository<ProjectUserEntity>> _projectUserRepoMock = new();
        private readonly CreateProjectCommandService _service;

        public CreateProjectCommandServiceTests()
        {
            _service = new CreateProjectCommandService(
                _mapperMock.Object,
                _projectRepoMock.Object,
                _projectUserRepoMock.Object);
        }

        [Fact]
        public async Task CreateProject_ShouldCreateProjectSuccessfully()
        {
            // Arrange
            var command = new CreateProjectRequestCommand
            {
                Name = "New Project",
                Description = "Project Description",
                UserId = 1
            };

            var projectEntity = new ProjectEntity { Name = command.Name, Description = command.Description };
            const int projectId = 1;
            const int projectUserId = 2;

            _mapperMock.Setup(m => m.Map<ProjectEntity>(command)).Returns(projectEntity);
            _projectRepoMock.Setup(r => r.Create(projectEntity)).ReturnsAsync(projectId);
            _projectUserRepoMock.Setup(r => r.Create(It.IsAny<ProjectUserEntity>())).ReturnsAsync(projectUserId);

            // Act
            var result = await _service.CreateProject(command);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(projectId, result.ProjectId);
            Assert.Equal(projectUserId, result.ProjectUserId);
        }

        [Fact]
        public async Task CreateProject_ShouldThrowExceptionOnRepositoryError()
        {
            // Arrange
            var command = new CreateProjectRequestCommand { Name = "New Project", UserId = 1 };
            var projectEntity = new ProjectEntity { Name = command.Name };

            _mapperMock.Setup(m => m.Map<ProjectEntity>(command)).Returns(projectEntity);
            _projectRepoMock.Setup(r => r.Create(projectEntity)).ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.CreateProject(command));
            Assert.Equal("Database error", exception.Message);
        }
    }
}
