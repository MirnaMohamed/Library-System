using Business.DTOs;

namespace Business.Contracts
{
    public interface IAuthorService
    {
        Task<List<GetAuthorDto>> GetAllAuthorsAsync();
        Task<GetAuthorDto> GetAuthorByIdAsync(int id);
        Task CreateAuthorAsync(AuthorDTO author);
        Task UpdateAuthorAsync(int id, AuthorDTO author);
        Task DeleteAuthorAsync(int id);
        Task<bool> AuthorExistsByEmail(string email);
        Task<bool> AuthorExistsByFullname(string fullname);
    }
}
