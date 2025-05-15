

using Domain.Entities;

namespace Common.Contracts
{
    public interface IBookRepository: IRepository<Book>
    {
        Task<List<Book>> FilterBooks();
    }
}
