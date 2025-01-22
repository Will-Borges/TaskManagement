namespace Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Remove.Responses
{
    public class RemoveProjectResponse
    {
        public bool SuccesfullyDelete { get; set; }
        

        public void SetSuccesfullyDelete(bool succesfullyDelete)
        {
            SuccesfullyDelete = succesfullyDelete;
        }
    }
}
