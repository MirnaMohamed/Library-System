using Common.Contracts;
using Common.Exceptions;
using Data.Context;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    internal class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly LibraryDbContext _context;
        internal BookRepository(LibraryDbContext context): base(context) {
            _context = context;
        }
        public Task<List<Book>> FilterBooks()
        {
            throw new NotImplementedException();
        }

        public async override Task UpdateAsync(Book entity, params object[] id)
        {
            var existing = await _context.Books.FindAsync((int)id[0]);
            if (existing != null)
            {
                entity.GetType().GetProperty("Id")?.SetValue(entity, (int)id[0]);
                _context.Entry(existing).CurrentValues.SetValues(entity);
            }
            else
            {
                throw new NotFoundException($"Book with ID: {id[0]} is not found");
            }
        }
    }
}
