using ToDoApp.Domain.Enums;

namespace ToDoApp.Web.Api.Models
{
    public record UpsertToDoTaskDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CompleteDueDate { get; set; }

        public bool IsCompleted { get; set; }

        public PriorityLevel PriorityId { get; set; }

        public int AssignedUserId { get; set; }
    }
}
