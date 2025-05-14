using Common.Contracts;
using Data.Context;
using Domain.Entities;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext context;
        private IRepository<Book>? books;
        private IAuthorRepository? authors;
        private IRepository<BorrowingRecord>? borrows;

        public UnitOfWork(LibraryDbContext context)
        {
            this.context = context;
        }
        public IRepository<Book> BooksRepository
        {
            get
            {
                if (books == null)
                {
                    books = new Repository<Book>(context);
                }
                return books;
            }
        }

        public IAuthorRepository AuthorsRepository
        {
            get
            {
                if (authors == null)
                {
                    authors = new AuthorRepository(context);
                }
                return authors;
            }
        }

        public IRepository<BorrowingRecord> BorrowRepository
        {
            get
            {
                if (borrows == null)
                {
                    borrows = new Repository<BorrowingRecord>(context);
                }
                return borrows;
            }
        }

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
