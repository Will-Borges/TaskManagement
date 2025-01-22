using AutoMapper;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Remove;
using Eclipseworks.TaskManagement.Core.Domains.Abstractions.Repositories.Base;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks;
using Moq;

namespace Eclipseworks.TaskManagement.Tests.CommandServices.Tasks
{
    public class RemoveTaskRequestCommandServiceTests
    {
        private readonly Mock<IMapper> _mapperMock;
        private readonly Mock<IEntityWriteRepository<TaskEntity>> _taskEntityWriteRepositoryMock;
        private readonly RemoveTaskRequestCommandService _service;


        public RemoveTaskRequestCommandServiceTests()
        {
            _mapperMock = new Mock<IMapper>();
            _taskEntityWriteRepositoryMock = new Mock<IEntityWriteRepository<TaskEntity>>();
            _service = new RemoveTaskRequestCommandService(
                _mapperMock.Object,
                _taskEntityWriteRepositoryMock.Object
            );
        }


        [Fact]
        public async Task RemoveTask_ShouldReturnSuccess_WhenTaskRemoved()
        {
            // Arrange
            var taskId = 1;
            _taskEntityWriteRepositoryMock.Setup(r => r.Delete(It.IsAny<TaskEntity>())).ReturnsAsync(true);

            // Act
            var result = await _service.RemoveTask(taskId);

            // Assert
            Assert.True(result.SuccesfullyRemove);
            _taskEntityWriteRepositoryMock.Verify(r => r.Delete(It.Is<TaskEntity>(e => e.Id == taskId)), Times.Once);
        }

        [Fact]
        public async Task RemoveTask_ShouldThrowException_WhenRepositoryFails()
        {
            // Arrange
            var taskId = 1;
            _taskEntityWriteRepositoryMock.Setup(r => r.Delete(It.IsAny<TaskEntity>())).ThrowsAsync(new Exception("Database error"));

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => _service.RemoveTask(taskId));
            Assert.Equal("An error occurred while removing the task: Database error", exception.Message);
        }
    }
}
