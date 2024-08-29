namespace ToDoApp.Web.Api.Models
{
    /// <summary>
    /// Detailed representation of ToDoTask for single requests by Id
    /// </summary>
    public class ToDoTaskDetailsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CompleteDueDate { get; set; }

        public bool IsCompleted { get; set; }

        public BaseNamedViewModel Priority { get; set; }

        public BaseNamedViewModel AssignedUser { get; set; }
    }
}
