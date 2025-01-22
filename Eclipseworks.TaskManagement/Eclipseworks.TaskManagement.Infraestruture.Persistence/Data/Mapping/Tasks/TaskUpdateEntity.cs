using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Tasks
{
    [Table("tasks")]
    public class TaskUpdateEntity
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

        [Column("project_id")]
        public int ProjectId { get; set; }


        public TaskUpdateEntity() { }

        public TaskUpdateEntity(int id)
        {
            Id = id;
        }
    }
}
