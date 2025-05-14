using AutoMapper;
using Business.Contracts;
using Business.DTOs;
using Common.Contracts;
using Common.Exceptions;
using Domain.Entities;

namespace Business.Services.Implementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;


        public AuthorService(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            unitOfWork = _unitOfWork;
            mapper = _mapper;
        }

        public async Task<bool> AuthorExistsByEmail(string email)
        {
            return await unitOfWork.AuthorsRepository.AuthorExistsByEmail(email);
        
        }

        public async Task<bool> AuthorExistsByFullname(string fullname)
        {
            return await unitOfWork.AuthorsRepository.AuthorExistsByFullname(fullname);
        }

        public async Task CreateAuthorAsync(AuthorDTO authorDto)
        {
            Author author = mapper.Map<Author>(authorDto);
            bool emailExists = await AuthorExistsByEmail(author.Email);
            if (emailExists)
            {
                throw new AlreadyExistsException($"Email: {author.Email} already exists");
            }
            bool nameExists = await AuthorExistsByFullname(author.FullName);
            if (nameExists)
            {
                throw new AlreadyExistsException($"Name: {author.FullName} already exists");
            }
            await unitOfWork.AuthorsRepository.AddAsync(author);
            await unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAuthorAsync(int id)
        {
            Author author = await unitOfWork.AuthorsRepository.GetByIdAsync(id);
            if (author.Books.Count > 0)
            {
                throw new InvalidOperationException($"Author with id {id} cannot be deleted because they have books." +
                    " Consider deleting their books first.");
            }
            try
            {
                await unitOfWork.AuthorsRepository.Delete(id);
                await unitOfWork.SaveChangesAsync();
            }
            catch
            {
                throw; //let the controller view the exception
            }
        }


        public async Task<List<GetAuthorDto>> GetAllAuthorsAsync()
        {
            var authors = await unitOfWork.AuthorsRepository.GetAllAsync();
            List<GetAuthorDto> authorDtos = new List<GetAuthorDto>();
            authorDtos.AddRange(mapper.Map<IEnumerable<GetAuthorDto>>(authors));
            return authorDtos;
        }

        public async Task<GetAuthorDto> GetAuthorByIdAsync(int id)
        {
            Author author = await unitOfWork.AuthorsRepository.GetByIdAsync(id);
            return mapper.Map<GetAuthorDto>(author);
        }

        public async Task UpdateAuthorAsync(int id, AuthorDTO author)
        {
            Author exisitingAuthor = mapper.Map<Author>(author);
            await unitOfWork.AuthorsRepository.UpdateAsync(id, exisitingAuthor);
            
            await unitOfWork.SaveChangesAsync();

        }
    }
}
