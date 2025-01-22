namespace Eclipseworks.TaskManagement.Core.Domains.Domains.TaskHistories
{
    public class TaskHistory
    {
        public int Id { get; private set; }
        public int TaskId { get; private set; }
        public string FieldName { get; private set; } = string.Empty;
        public string OldValue { get; private set; } = string.Empty;
        public string NewValue { get; private set; } = string.Empty;
        public DateTime ChangedAt { get; private set; }
        public string ChangedBy { get; private set; } = string.Empty;
    }
}
