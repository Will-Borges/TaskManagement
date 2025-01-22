namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Create.Responses
{
    public class CreateTaskResponse
    {
        public int Id { get; set; }
        public bool ProjectSuccesfullyCreated { get; set; }
        

        public CreateTaskResponse(int id)
        {
            Id = id;
            ProjectSuccesfullyCreated = true;
        }

        public CreateTaskResponse()
        {
            ProjectSuccesfullyCreated = false;
        }
    }
}
