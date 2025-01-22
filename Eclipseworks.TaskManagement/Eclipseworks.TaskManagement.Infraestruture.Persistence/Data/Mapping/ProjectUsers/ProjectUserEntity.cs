using Eclipseworks.TaskManagement.Core.Domains.Domains.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.ProjectUsers
{
    [Table("project_user")]
    public class ProjectUserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        [Required]
        public int UserId { get; set; }

        [Column("project_id")]
        [Required]
        public int ProjectId { get; set; }


        public ProjectUserEntity() { }

        public void setProjectId(int projectId)
        {
            ProjectId = projectId;
        }
    }
}
