using Business.DTOs;
using Services.DTOs;

namespace Business.Services.Contracts
{
    public interface IBookService
    {
        Task<List<GetBookDTO>> GetAllBooksAsync();
        Task<GetBookDTO?> GetBookByIdAsync(int id);
        Task CreateBookAsync(AddBookDTO book);
        Task UpdateBookAsync(int id, AddBookDTO book);
        void DeleteBookAsync(int id);
    }
}
