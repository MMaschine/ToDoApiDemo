using ToDoApp.Domain.Enums;

namespace ToDoApp.Web.Api.Models
{
    /// <summary>
    /// General representation of the ToDoTask to be returned in lists
    /// </summary>
    public class ToDoTaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CompleteDueDate { get; set; }

        public bool IsCompleted { get; set; }

        public PriorityLevel PriorityId { get; set; }

        public int AssignedUserId { get; set; }
    }
}
