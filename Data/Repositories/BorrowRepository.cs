using Common.Contracts;
using Data.Context;
using Domain.Entities;

namespace Data.Repositories
{
    public class BorrowRepository: Repository<BorrowingRecord>, IBorrowRepository
    {
        private readonly LibraryDbContext _context;
        public BorrowRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<BorrowingRecord?> Find(int id, DateTime borrowDate)
        {
            return await _context.BorrowRecords.FindAsync(id, borrowDate);
        }
    }
}
