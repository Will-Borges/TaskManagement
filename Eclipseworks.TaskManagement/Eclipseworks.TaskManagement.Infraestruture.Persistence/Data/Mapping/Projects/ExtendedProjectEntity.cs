using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects
{
    public class ExtendedProjectEntity
    {
        [Key]
        public int project_id { get; set; } 
        public string projects_name { get; set; } = string.Empty;
        public string projects_description { get; set; } = string.Empty;
        public int tasks_id { get; set; }
        public string tasks_title { get; set; } = string.Empty;
        public string tasks_description { get; set; } = string.Empty;
        public DateTime tasks_due_date { get; set; }
        public int tasks_status { get; set; }
        public int tasks_priority { get; set; }
        public int users_id { get; set; }
        public string users_name { get; set; } = string.Empty;
        public string users_position { get; set; } = string.Empty;

    }
}
