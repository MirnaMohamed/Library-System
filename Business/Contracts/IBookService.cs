using Business.DTOs;
using Common.Filtration;
using Services.DTOs;

namespace Business.Services.Contracts
{
    public interface IBookService
    {
        Task<List<GetBookDTO>> GetAllBooksAsync();
        Task<GetBookDTO?> GetBookByIdAsync(int id);
        Task CreateBookAsync(AddBookDTO book);
        Task UpdateBookAsync(int id, AddBookDTO book);
        Task DeleteBookAsync(int id);
        Task<List<GetBookDTO>> FilterBooksAsync(BookSearchCriteria searchCriteria);
        Task<List<GetBookDTO>> GetAvailableBooksAsync();
        Task<List<GetBookDTO>> GetBorrowedBooksAsync();
    }
}
