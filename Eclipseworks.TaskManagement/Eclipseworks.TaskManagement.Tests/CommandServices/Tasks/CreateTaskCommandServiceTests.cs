using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;
using Moq;

namespace Eclipseworks.TaskManagement.Tests.CommandServices.Tasks
{
    public class CreateTaskCommandServiceTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IEntityWriteRepository<TaskEntity>> _taskRepoMock = new();
        private readonly Mock<IProjectRepository> _projectRepoMock = new();
        private readonly CreateTaskCommandService _service;

        public CreateTaskCommandServiceTests()
        {
            _service = new CreateTaskCommandService(
                _mapperMock.Object,
                _taskRepoMock.Object,
                _projectRepoMock.Object);
        }

        [Fact]
        public async Task CreateTask_ShouldCreateTaskSuccessfully()
        {
            // Arrange
            var command = new CreateTaskRequestCommand
            {
                Title = "New Task",
                Description = "Task Description",
                DueDate = DateTime.Now.AddDays(5),
                Status = StatusTask.Pending,
                ProjectId = 1
            };

            _mapperMock.Setup(m => m.Map<TaskProject>(command)).Returns(new TaskProject { Title = command.Title });
            _mapperMock.Setup(m => m.Map<TaskEntity>(command)).Returns(new TaskEntity());
            _taskRepoMock.Setup(r => r.Create(It.IsAny<TaskEntity>())).ReturnsAsync(1);

            // Act
            var result = await _service.CreateTask(command);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task CheckMaximumNumberTasks_ShouldThrowExceptionWhenLimitExceeded()
        {
            // Arrange
            var taskProject = new TaskProject { Id = 1 };
            _projectRepoMock.Setup(r => r.CountProjectsByTaskId(taskProject.Id)).ReturnsAsync(21);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.CheckMaximumNumberTasks(taskProject));
            Assert.Equal("There are already 20 tasks associated with this project.", exception.Message);
        }

        [Fact]
        public async Task ExecuteCreateTask_ShouldReturnResponseWhenSuccessful()
        {
            // Arrange
            var taskEntity = new TaskEntity { Id = 1 };
            _taskRepoMock.Setup(r => r.Create(It.IsAny<TaskEntity>())).ReturnsAsync(1);

            // Act
            var result = await _service.ExecuteCreateTask(taskEntity);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task ExecuteCreateTask_ShouldThrowExceptionOnError()
        {
            // Arrange
            var taskEntity = new TaskEntity { Id = 1 };
            _taskRepoMock.Setup(r => r.Create(It.IsAny<TaskEntity>())).ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.ExecuteCreateTask(taskEntity));
            Assert.Equal("Database error", exception.Message);
        }
    }
}
