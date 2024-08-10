using ToDoApp.Domain.Models;

namespace ToDoApp.Logic.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Request of all exisiting users
        /// </summary>
        Task<IReadOnlyCollection<User>> GetAllUsersAsync();

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id">User's id</param>
        Task<User?> GetUserAsync(int id);

        /// <summary>
        /// Create new user
        /// </summary>
        /// <param name="user">User to add</param>
        Task<int> AddUserAsync(User user);

        /// <summary>
        /// Delete existing user with given id
        /// </summary>
        Task DeleteUserAsync(int id);
    }
}