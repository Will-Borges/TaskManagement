using Eclipseworks.TaskManagement.Core.Application.Abstractions.Commands;
using Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Requests;
using Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Dapper.Querys.SearchProjectsByUserId;
using Microsoft.AspNetCore.Mvc;

namespace Eclipseworks.TaskManagement.Controllers.Projects
{
    [Route("v1/Project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly ISearchProjectsByUserIdQuery _searchProjectsByUserIdQuery;
        private readonly ICreateProjectCommandService _createProjectCommandService;
        private readonly IRemoveProjectCommandService _removeProjectCommandService;


        public ProjectController(
            ISearchProjectsByUserIdQuery listProjectsByUserIdCommandService,
            ICreateProjectCommandService createProjectCommandService,
            IRemoveProjectCommandService removeProjectCommandService)
        {
            _searchProjectsByUserIdQuery = listProjectsByUserIdCommandService;
            _createProjectCommandService = createProjectCommandService;
            _removeProjectCommandService = removeProjectCommandService;
        }


        [HttpPost]
        [Route("create-project")]
        public async Task<IActionResult> CreateProject([FromBody] CreateProjectRequestCommand command)
        {
            try
            {
                var response = await _createProjectCommandService.CreateProject(command);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("list-projects-userId")]
        public async Task<IActionResult> SearchProjectsByUserId([FromQuery] int userId)
        {
            try
            {
                var response = await _searchProjectsByUserIdQuery.SearchProjectsByUserId(userId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("remove-project")]
        public async Task<IActionResult> RemoveProject([FromQuery] int projectId)
        {
            try
            {
                var response = await _removeProjectCommandService.RemoveProject(projectId);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
