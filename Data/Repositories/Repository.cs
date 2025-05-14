using Common.Contracts;
using Common.Exceptions;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Data.Context;

namespace Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryDbContext context;

        public Repository(LibraryDbContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(T entity)
        {
            await context.Set<T>().AddAsync(entity);
        }

        public Task Delete(int id)
        {
            T? existingEntity = context.Set<T>().Find(id);
            if (existingEntity != null)
            {
                context.Set<T>().Remove(existingEntity);
                return Task.CompletedTask;
            }
            else
            {
                throw new NotFoundException($"Can't remove {typeof(T).Name} with ID: {id}. \nID {id} is not found.");
            }
        }

        public async Task<bool> Exists(int id) 
        {
            T? entity = await context.Set<T>().FindAsync(id);
            return entity != null;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(context.Set<T>().AsQueryable());
        }

        public async Task<T> GetByIdAsync(int id)
        {
            T? entity = await context.Set<T>().FindAsync(id);
            if(entity == null)
            {
                throw new NotFoundException($"{typeof(T).Name} with ID: {id} is not found");
            }
            return entity;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            var existing = await context.Set<T>().FindAsync(id);
            if (existing != null)
            {
                entity.GetType().GetProperty("Id")?.SetValue(entity, id);
                context.Entry(existing).CurrentValues.SetValues(entity);
            }
            else
            {
                throw new NotFoundException($"{typeof(T).Name} with ID: {id} is not found");
            }
        }
    }
}
