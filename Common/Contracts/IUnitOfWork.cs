using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IUnitOfWork
    {
        public IRepository<Book> BooksRepository { get; }

        public IAuthorRepository AuthorsRepository { get; }
        public IRepository<BorrowingRecord> BorrowRepository { get; }

        public Task SaveChangesAsync();
    }
}
