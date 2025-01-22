namespace Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Results
{
    public class CreateProjectResponse
    {
        public int ProjectId { get; set; }
        public int ProjectUserId { get; set; }
        public bool ProjectSuccesfullyCreated { get; set; }


        public CreateProjectResponse(int projectId, int projectUserId)
        {
            ProjectId = projectId;
            ProjectSuccesfullyCreated = true;
            ProjectUserId = projectUserId;
        }

        public CreateProjectResponse()
        {
            ProjectSuccesfullyCreated = false;
        }
    }
}
