// namespace BookNation.Logic;

using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAuthorsAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(AuthorDto authorDto);
        Task<Author> RemoveAuthorAsync(int removeId);
    }
}
