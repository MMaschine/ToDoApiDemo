using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using ToDoApp.DataAccess.DataSources.Interfaces;
using ToDoApp.Domain.Models;

namespace ToDoApp.DataAccess.DataSources
{
    public class GenericDataSource<T>(ToDoContext context) : IGenericDataSource<T> where T : BaseEntity
    {
        private readonly DbSet<T> _set = context.Set<T>();

        /// <inheritdoc />
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _set.AsNoTracking()
                .ToListAsync();
        }

        /// <inheritdoc />
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _set.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc />
        public async Task<IReadOnlyList<T>> GetItemsAsync(Expression<Func<T, bool>> filter)
        {
            var entities = await _set.Where(filter)
                .AsNoTracking()
                .ToListAsync();

            return entities.AsReadOnly();
        }

        /// <inheritdoc />
        public IQueryable<T> GetQueryableItems()
        {
            return _set.AsNoTracking();
        }

        /// <inheritdoc />
        public async Task<T> AddAsync(T item)
        {
            await _set.AddAsync(item);
            await context.SaveChangesAsync();

            return item;
        }

        /// <inheritdoc />
        public async Task UpdateAsync(T item)
        {
            _set.Update(item);
            await context.SaveChangesAsync();
        }

        /// <inheritdoc />
        public async Task DeleteAsync(T item)
        {
            _set.Remove(item);
            await context.SaveChangesAsync();
        }
    }
}
