using ToDoApp.DataAccess.DataSources.Interfaces;
using ToDoApp.Domain.Exceptions;
using ToDoApp.Domain.Models;
using ToDoApp.Logic.Interfaces;

namespace ToDoApp.Logic.Services
{
    public class UserService(IGenericDataSource<User> dataSource) : IUserService
    {
        /// <inheritdoc />
        public async Task<IReadOnlyCollection<User>> GetAllUsersAsync()
        {
            return await dataSource.GetAllAsync();
        }

        /// <inheritdoc />
        public async Task<User?> GetUserAsync(int id)
        {
            return await dataSource.GetByIdAsync(id);
        }

        /// <inheritdoc />
        public async Task<int> AddUserAsync(User user)
        {
            ValidateUser(user);

            return (await dataSource.AddAsync(user)).Id;
        }

        /// <inheritdoc />
        public async Task DeleteUserAsync(int id)
        {
            var userToDelete = await dataSource.GetByIdAsync(id);

            if (userToDelete == null)
            {
                throw new EntityValidationException($"User with id {id} doesn't exist");
            }

            await dataSource.DeleteAsync(userToDelete);
        }

        private void ValidateUser(User user)
        {
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new FieldValidationErrorException("Name", "User name can't be empty");
            }
        }
    }
}
