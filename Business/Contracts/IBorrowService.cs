using Domain.Entities;

namespace Business.Contracts
{
    public interface IBorrowService
    {
        Task<List<BorrowingRecord>> GetBorrowingRecordsByBookId(int bookId);
        Task<List<BorrowingRecord>> GetAll();
        Task BorrowBookAsync(int bookId, DateTime? borrowDate);
        Task ReturnBookAsync(int bookId, DateTime? returnDate);
    }
}
