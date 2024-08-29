using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Models
{

    public class ToDoTask : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CompleteDueDate { get; set; }

        public bool IsCompleted { get; set; }

        public PriorityLevel PriorityId { get; set; }

        public Priority Priority { get; set; }

        public int? AssignedUserId { get; set; }

        public User AssignedUser { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }
    }
}
