using EntityFrameworkCore.Triggered;
using ToDoApp.Domain.Models;

namespace ToDoApp.DataAccess.Triggers
{
    internal class SetToDoTaskModifiedDateTrigger : IBeforeSaveTrigger<ToDoTask>
    {
        public Task BeforeSave(ITriggerContext<ToDoTask> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Modified)
            {
                context.Entity.LastModifiedDate = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }
    }
}
