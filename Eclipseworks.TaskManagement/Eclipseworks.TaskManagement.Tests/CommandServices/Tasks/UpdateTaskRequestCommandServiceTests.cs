using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Requests;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;
using Moq;

namespace Eclipseworks.TaskManagement.Tests.CommandServices.Projects
{
    public class UpdateTaskRequestCommandServiceTests
    {
        private readonly Mock<IMapper> _mapperMock = new();
        private readonly Mock<IEntityWriteRepository<TaskUpdateEntity>> _taskRepoMock = new();
        private readonly Mock<ICreateTaskHistoryCommandService> _createTaskHistoryCommandServiceMock = new();
        private readonly UpdateTaskRequestCommandService _service;

        public UpdateTaskRequestCommandServiceTests()
        {
            _service = new UpdateTaskRequestCommandService(
                _mapperMock.Object,
                _taskRepoMock.Object,
                _createTaskHistoryCommandServiceMock.Object
            );
        }

        [Fact]
        public async Task UpdateTask_ShouldUpdateTaskSuccessfully()
        {
            // Arrange
            var command = new UpdateTaskRequestCommand
            {
                Id = 1,
                Title = "Updated Task",
                Description = "Updated Description",
                DueDate = DateTime.Now.AddDays(10),
                Status = StatusTask.Pending
            };

            _mapperMock.Setup(m => m.Map<TaskEntity>(command)).Returns(new TaskEntity());
            _taskRepoMock.Setup(r => r.UpdateAsync(It.IsAny<TaskUpdateEntity>())).ReturnsAsync(true);

            // Act
            var result = await _service.UpdateTask(command);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.SuccesfullyCreated);
        }

        [Fact]
        public async Task UpdateTask_ShouldThrowExceptionOnRepositoryError()
        {
            // Arrange
            var command = new UpdateTaskRequestCommand { Id = 1, Title = "Updated Task" };

            _mapperMock.Setup(m => m.Map<TaskEntity>(command)).Returns(new TaskEntity());
            _taskRepoMock.Setup(r => r.UpdateAsync(It.IsAny<TaskUpdateEntity>())).ThrowsAsync(new Exception("Repository error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.UpdateTask(command));
            Assert.Equal("Repository error", exception.Message);
        }
    }
}
