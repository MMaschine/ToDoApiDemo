namespace ToDoApp.Domain.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public List<ToDoTask> UsersTasks { get; set; }
    }
}
