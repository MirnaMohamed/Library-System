
namespace Common.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<T?> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity, params object[] id);
        Task Delete(int id);

    }
}
