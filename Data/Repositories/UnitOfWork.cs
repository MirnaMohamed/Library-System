using Common.Contracts;
using Data.Context;
using Domain.Entities;

namespace Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly LibraryDbContext context;
        private IBookRepository? books;
        private IAuthorRepository? authors;
        private IBorrowRepository? borrows;

        public UnitOfWork(LibraryDbContext context)
        {
            this.context = context;
        }
        public IBookRepository BooksRepository
        {
            get
            {
                if (books == null)
                {
                    books = new BookRepository(context);
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

        public IBorrowRepository BorrowRepository
        {
            get
            {
                if (borrows == null)
                {
                    borrows = new BorrowRepository(context);
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
