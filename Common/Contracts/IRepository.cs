using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<IQueryable<T>> GetAllAsync();
        Task<bool> Exists(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task Delete(int id);

    }
}
