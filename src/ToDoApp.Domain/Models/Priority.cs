using ToDoApp.Domain.Enums;

namespace ToDoApp.Domain.Models
{
    public class Priority
    {
        public PriorityLevel Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<ToDoTask> Tasks { get; set; }
    }
}
