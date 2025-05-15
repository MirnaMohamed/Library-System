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
        public IBookRepository BooksRepository { get; }

        public IAuthorRepository AuthorsRepository { get; }
        public IBorrowRepository BorrowRepository { get; }

        public Task SaveChangesAsync();
    }
}
