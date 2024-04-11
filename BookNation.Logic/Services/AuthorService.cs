using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using BookNation.Logic.Services.Interfaces;

namespace BookNation.Logic.Services
{
    public class AuthorService : IAuthorService
    {
        public readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Author> AddAuthorAsync(AuthorDto authorDto)
        {
            return await _authorRepository.AddAuthorAsync(authorDto);
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _authorRepository.GetAuthorsAsync();
        }

        public async Task<Author> GetAuthorAsync(int id)
        {
            return await _authorRepository.GetAuthorAsync(id);
        }

        public async Task<Author> RemoveAuthorAsync(int removeId)
        {
            return await _authorRepository.RemoveAuthorAsync(removeId);
        }
    }
}
