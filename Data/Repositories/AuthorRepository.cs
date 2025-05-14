

using Common.Contracts;
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
