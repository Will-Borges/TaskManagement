using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Requests;
using Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Requests;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SeachTasksByProjectId;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.TaskManagement.Controllers.TaskController
{
    public class TaskController : ControllerBase
    {
        private readonly ICreateTaskCommandService _createTaskCommandService;
        private readonly ISeachTasksByProjectIdQuery _seachTasksByProjectIdQuery;
        private readonly IUpdateTaskRequestCommandService _updateTaskRequestCommandService;
        private readonly IRemoveTaskRequestCommandService _removeTaskRequestCommandService;


        public TaskController(
            ICreateTaskCommandService createTaskCommandService,
            ISeachTasksByProjectIdQuery seachTasksByProjectIdQuery,
            IUpdateTaskRequestCommandService updateTaskRequestCommandService,
            IRemoveTaskRequestCommandService removeTaskRequestCommandService)
        {
            _createTaskCommandService = createTaskCommandService;
            _seachTasksByProjectIdQuery = seachTasksByProjectIdQuery;
            _updateTaskRequestCommandService = updateTaskRequestCommandService;
            _removeTaskRequestCommandService = removeTaskRequestCommandService;
        }


        [HttpPost]
        [Route("create-task")]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequestCommand command)
        {
            try
            {
                var response = await _createTaskCommandService.CreateTask(command);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("seach-tasks-by-projectId")]
        public async Task<IActionResult> SeachTasksByProjectId([FromQuery] int projectId)
        {
            try
            {
                var response = await _seachTasksByProjectIdQuery.SeachTasksByProjectId(projectId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("update-task")]
        public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskRequestCommand command)
        {
            try
            {
                var response = await _updateTaskRequestCommandService.UpdateTask(command);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove-task")]
        public async Task<IActionResult> RemoveTask([FromQuery] int taskId)
        {
            try
            {
                var response = await _removeTaskRequestCommandService.RemoveTask(taskId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
// gerar dockerFile novamente quando terminar
// para iniciar o projeto rode ... na pasta do dockerfile
