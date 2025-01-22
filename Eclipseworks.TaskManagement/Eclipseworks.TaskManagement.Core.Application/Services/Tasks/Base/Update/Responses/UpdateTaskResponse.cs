namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Update.Responses
{
    public class UpdateTaskResponse
    {
        public bool SuccesfullyCreated { get; set; }


        public UpdateTaskResponse(bool succesfullyCreated)
        {
            SuccesfullyCreated = succesfullyCreated;
        }
    }
}
