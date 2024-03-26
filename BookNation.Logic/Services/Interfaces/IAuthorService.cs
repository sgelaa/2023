using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAuthorAsync();
        Task<Author> GetAuthorAsync(int id);
        Task<Author> AddAuthorAsync(AuthorDto authorDto);
        Task<Author> RemoveAuthorAsync(int removeId);
    }
}
