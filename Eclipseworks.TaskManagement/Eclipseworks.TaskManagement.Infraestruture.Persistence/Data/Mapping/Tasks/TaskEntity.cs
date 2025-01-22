using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks
{
    [Table("tasks")]
    public class TaskEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; } = string.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Column("due_date")]
        [Required]
        public DateTime DueDate { get; set; }

        [Column("status")]
        [Required]
        public int Status { get; set; }

        [Column("priority")]
        [Required]
        public int Priority { get; set; }

        [Column("project_id")]
        // [ForeignKey("Project")]
        public int ProjectId { get; set; }
        // public ProjectEntity Project { get; set; } = new ProjectEntity();   


        public TaskEntity() { }

        public TaskEntity(int id)
        {

            Id = id;
        }
    }
}
