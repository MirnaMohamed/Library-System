

using Common.Contracts;
using Common.Exceptions;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        private readonly LibraryDbContext _context;
        public AuthorRepository(LibraryDbContext context) : base(context)
        {
            _context = context;
        }
        public async override Task UpdateAsync(Author entity, params object[] id)
        {
            var existing = await _context.Authors.FindAsync((int)id[0]);
            if (existing != null)
            {
                entity.GetType().GetProperty("Id")?.SetValue(entity, (int)id[0]);
                _context.Entry(existing).CurrentValues.SetValues(entity);
            }
            else
            {
                throw new NotFoundException($"Author with ID: {id[0]} is not found");
            }
        }

        public async Task<bool> AuthorExistsByEmail(string email)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(a => a.Email == email);
            return author != null;
        }

        public async Task<bool> AuthorExistsByFullname(string fullname)
        {
            var author = await _context.Authors.SingleOrDefaultAsync(a => a.FullName == fullname);
            return author != null;
        }
    }
}
