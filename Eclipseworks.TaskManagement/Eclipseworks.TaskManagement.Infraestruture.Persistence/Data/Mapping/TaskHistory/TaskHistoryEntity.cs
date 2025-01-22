using System.ComponentModel.DataAnnotations.Schema;

namespace Eclipseworks.TaskManagement.Infraestruture.Persistence.Data.Mapping.TaskHistory
{
    [Table("task_histories")]
    public class TaskHistoryEntity
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("task_id")]
        public int TaskId { get; set; }

        [Column("field_name")]
        public string FieldName { get; set; } = string.Empty;

        [Column("old_value")]
        public string OldValue { get; set; } = string.Empty;

        [Column("new_value")]
        public string NewValue { get; set; } = string.Empty;

        [Column("changed_at")]
        public DateTime ChangedAt { get; set; }

        [Column("changed_by")]
        public int ChangedBy { get; set; }


        public TaskHistoryEntity() { }


        public TaskHistoryEntity(
            int taskId,
            string fieldName,
            string oldValue,
            string newValue,
            DateTime changedAt,
            int changedBy)
        {
            TaskId = taskId;
            FieldName = fieldName;
            OldValue = oldValue;
            NewValue = newValue;
            ChangedAt = changedAt;
            ChangedBy = changedBy;
        }
    }
}
