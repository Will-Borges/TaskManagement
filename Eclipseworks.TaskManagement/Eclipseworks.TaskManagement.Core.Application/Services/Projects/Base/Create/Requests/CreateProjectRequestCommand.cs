namespace Eclipseworks.TaskManagement.Core.Application.Services.Projects.Base.Create.Requests
{
    public class CreateProjectRequestCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int UserId{ get; set; } // criado por 
    }
}
