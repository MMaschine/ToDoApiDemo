using Microsoft.EntityFrameworkCore;
using ToDoApp.DataAccess.DataSources.Interfaces;
using ToDoApp.Domain.Enums;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Models;
using ToDoApp.Logic.Interfaces;

namespace ToDoApp.Logic.Services
{
    public class ToDoTaskService(IGenericDataSource<ToDoTask> taskDataSource,
        IGenericDataSource<User> userDataSource) : IToDoTaskService
    {
        /// <inheritdoc />
        public async Task<IReadOnlyCollection<ToDoTask>> GetAllToDoTaskAsync()
        {
            return await taskDataSource.GetAllAsync();
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<ToDoTask>> GetFilteredToDoTaskAsync(ToDoTasksFilter filter)
        {
            var query = taskDataSource.GetQueryableItems();

            if (!string.IsNullOrEmpty(filter.Title))
            {
                query = query.Where(x => x.Title == filter.Title);
            }

            if (filter.AssignedUserId.HasValue)
            {
                var assignedUserId = filter.AssignedUserId.Value;

                query = assignedUserId != 0 ? query = query.Where(x => x.AssignedUserId == assignedUserId)
                    : query.Where(x => x.AssignedUserId == null);
            }

            if (filter.IsCompleted.HasValue)
            {
                query = query.Where(x => x.IsCompleted == filter.IsCompleted.Value);
            }

            if (filter.PriorityLevel.HasValue)
            {
                var priorirtValue = (PriorityLevel)filter.PriorityLevel.Value;
                query = query.Where(x => x.PriorityId == priorirtValue);
            }

            return await query.ToListAsync();
        }


        /// <inheritdoc />
        public async Task<ToDoTask?> GetTaskByIdAsync(int id)
        {
            return await taskDataSource.GetQueryableItems()
                .Include(x => x.AssignedUser)
                .Include(x => x.Priority)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<ToDoTask>> GetTasksAssignedToTheUser(int userId)
        {
            return await taskDataSource.GetItemsAsync(x => x.AssignedUserId == userId);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<ToDoTask>> GetTasksFilteredByCompletionAsync(bool isCompleted)
        {
            return await taskDataSource.GetItemsAsync(x => x.IsCompleted == isCompleted);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyCollection<ToDoTask>> GetTasksFilteredByPriorityAsync(PriorityLevel level)
        {
            return await taskDataSource.GetItemsAsync(x => x.PriorityId == level);
        }

        /// <inheritdoc />
        public async Task<ToDoTask> AssignUserToTheTaskAsync(int taskId, int userId)
        {
            var task = await taskDataSource.GetByIdAsync(taskId);

            if (task == null)
            {
                throw new EntityValidationException($"Task with the id {taskId} not exists");
            }

            if (task.AssignedUserId != userId)
            {
                if (!await IsUserExistsAsync(userId))
                {
                    throw new EntityValidationException($"Can't assign user with the id {userId}. User doesn't exist");
                }

                task.AssignedUserId = userId;
                await taskDataSource.UpdateAsync(task);
            }

            return task;
        }

        /// <inheritdoc />'
        public async Task<ToDoTask> CompleteTheTaskAsync(int taskId)
        {
            var task = await taskDataSource.GetByIdAsync(taskId);

            if (task == null)
            {
                throw new EntityValidationException($"The task with id {taskId} doesn't exists");
            }

            task.IsCompleted = true;

            await taskDataSource.UpdateAsync(task);

            return task;
        }

        /// <inheritdoc />
        public async Task<int> CreateNewTaskAsync(ToDoTask task)
        {
            await ValidateToDoTask(task);

            var result = await taskDataSource.AddAsync(task);

            return result.Id;
        }

        /// <inheritdoc />
        public async Task UpdateTaskAsync(ToDoTask task)
        {
            if (task.Id == 0)
            {
                throw new FieldValidationErrorException("Id", "The id of updating ToDoTask is 0. Can't update task not added to DB");
            }

            await ValidateToDoTask(task);

            await taskDataSource.UpdateAsync(task);
        }

        /// <inheritdoc />
        public async Task DeleteToDoTaskAsync(int taskId)
        {
            var taskToDelete = await taskDataSource.GetByIdAsync(taskId);

            if (taskToDelete != null)
            {
                await taskDataSource.DeleteAsync(taskToDelete);
            }
            else
            {
                throw new EntityValidationException($"ToDoTask with the id {taskId} doesn't exists");
            }
        }

        private async Task ValidateToDoTask(ToDoTask task)
        {
            if (string.IsNullOrEmpty(task.Title))
            {
                throw new FieldValidationErrorException("Title", "Task's title can't be empty");
            }

            if (task.AssignedUserId.HasValue && task.AssignedUserId > 0)
            {
                if (!await IsUserExistsAsync(task.AssignedUserId.Value))
                {
                    throw new EntityValidationException($"Can't create the task assigned to the user with Id {task.AssignedUserId}. The user doesn't exist");

                }
            }
        }

        private async Task<bool> IsUserExistsAsync(int userId)
        {
            var user = await userDataSource.GetByIdAsync(userId);

            return user != null;
        }
    }
}
