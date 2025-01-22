using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.TaskManagement.Controllers.Performances
{
    public class TaskHistoryController : ControllerBase
    {
        private readonly ISearchTaskHistoryCommandService _searchTaskHistoryCommandService;

        public TaskHistoryController(ISearchTaskHistoryCommandService searchTaskHistoryCommandService)
        {
            _searchTaskHistoryCommandService = searchTaskHistoryCommandService;
        }


        [HttpGet]
        [Route("seach-all-tasks-histories")]
        public async Task<IActionResult> SeachTasksByProjectId()
        {
            try
            {
                var response = await _searchTaskHistoryCommandService.SeachAllTaskHistories();
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
