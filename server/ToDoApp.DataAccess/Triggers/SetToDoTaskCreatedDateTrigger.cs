using EntityFrameworkCore.Triggered;
using ToDoApp.Domain.Models;

namespace ToDoApp.DataAccess.Triggers
{
    internal class SetToDoTaskCreatedDateTrigger : IBeforeSaveTrigger<ToDoTask>
    {
        public Task BeforeSave(ITriggerContext<ToDoTask> context, CancellationToken cancellationToken)
        {
            if (context.ChangeType == ChangeType.Added)
            {
                context.Entity.CreatedDate = DateTime.UtcNow;
                context.Entity.LastModifiedDate = DateTime.UtcNow;
            }

            return Task.CompletedTask;
        }
    }
}
