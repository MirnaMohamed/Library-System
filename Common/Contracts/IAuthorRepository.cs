using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Contracts
{
    public interface IAuthorRepository : IRepository<Author>
    {
        //Task<Author?> GetByEmailAsync(string email);
        //Task<Author?> GetByFullnameAsync(string fullname);
        //Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<bool> AuthorExistsByEmail(string email);
        Task<bool> AuthorExistsByFullname(string fullname);
    }
}
