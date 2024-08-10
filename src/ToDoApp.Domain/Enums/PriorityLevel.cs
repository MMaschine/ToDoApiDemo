using System.ComponentModel;

namespace ToDoApp.Domain.Enums
{
    public enum PriorityLevel
    {
        [Description("Low")]
        Low = 1,

        [Description("Medium")]
        Medium,

        [Description("High")]
        High,

        [Description("Critical")]
        Critical,
    }
}
