using ToDoApp.Domain.Filters;
using ToDoApp.Domain.Models;


namespace ToDoApp.Logic.Interfaces
{
    public interface IToDoTaskService
    {
        /// <summary>
        /// Get all exisiting tasks
        /// </summary>
        Task<IReadOnlyCollection<ToDoTask>> GetAllToDoTaskAsync();

        /// <summary>
        /// Get number of tasks according to the filter params
        /// </summary>
        /// <param name="filter">filter params to request tasks</param>
        /// <returns>Filtered collection of tasks</returns>
        Task<IReadOnlyCollection<ToDoTask>> GetFilteredToDoTaskAsync(ToDoTasksFilter filter);

        /// <summary>
        /// Get the task with the given id
        /// </summary>
        /// <param name="id">Id of the task to get</param>
        Task<ToDoTask?> GetTaskByIdAsync(int id);

        /// <summary>
        /// Add new task to DB
        /// </summary>
        /// <param name="task">The task to be added</param>
        /// <returns>Id of the new ToDoTask</returns>
        Task<int> CreateNewTaskAsync(ToDoTask task);

        /// <summary>
        /// Update task with given data
        /// </summary>
        /// <param name="task">New state of task to update</param>
        Task UpdateTaskAsync(ToDoTask task);

        /// <summary>
        /// Assign user to the task
        /// </summary>
        /// <param name="taskId">Id of the task to assign a user</param>
        /// <param name="userId">Id of the user to be assigned</param>
        Task<ToDoTask> AssignUserToTheTaskAsync(int taskId, int userId);

        /// <summary>
        /// Set task to IsCompleted status
        /// </summary>
        /// <param name="taskId">id of the task to complete</param>
        Task<ToDoTask> CompleteTheTaskAsync(int taskId);

        /// <summary>
        /// Delete the task with a given id
        /// </summary>
        /// <param name="taskId">id to delete the task</param>
        Task DeleteToDoTaskAsync(int taskId);


    }
}
