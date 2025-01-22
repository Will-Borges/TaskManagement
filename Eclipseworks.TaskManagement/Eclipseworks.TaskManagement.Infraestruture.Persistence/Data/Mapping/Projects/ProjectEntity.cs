using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.Projects
{
    [Table("projects")]
    public class ProjectEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [Column("description")]
        [Required]
        public string Description { get; set; } = string.Empty;


        public ProjectEntity() { }

        public ProjectEntity(int id)
        {
            Id = id;
        }
    }
}
