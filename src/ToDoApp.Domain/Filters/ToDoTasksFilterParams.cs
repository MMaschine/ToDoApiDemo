namespace ToDoApp.Domain.Filters
{
    public class ToDoTasksFilter
    {
        public string? Title { get; set; }

        public bool? IsCompleted { get; set; }

        public int? AssignedUserId { get; set; }

        public int? PriorityLevel { get; set; }
    }
}
