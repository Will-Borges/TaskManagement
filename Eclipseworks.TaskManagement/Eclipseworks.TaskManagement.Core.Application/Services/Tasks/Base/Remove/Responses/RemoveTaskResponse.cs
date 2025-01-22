namespace Eclipseworks.TaskManagement.Core.Application.Services.Tasks.Base.Remove.Responses
{
    public class RemoveTaskResponse
    {
        public bool SuccesfullyRemove { get; set; }


        public RemoveTaskResponse(bool succesfullyCreated)
        {
            SuccesfullyRemove = succesfullyCreated;
        }
    }
}
