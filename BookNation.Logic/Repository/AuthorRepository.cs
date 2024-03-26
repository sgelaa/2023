using BookNation.DataAccess.Data;
using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Logic.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAuthorAsync(AuthorDto authorDto)
        {
            var author = new Author
            {
                Name = authorDto.Name,
                Surname = authorDto.Surname,
                DateAdded = DateTime.Now
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new Author
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                DateAdded = author.DateAdded
            };
        }

        public async Task<IEnumerable<Author>> GetAuthorsAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetAuthorAsync(int id)
        {
            var author = await _context.Authors
                .Where(author => author.Id == id).FirstOrDefaultAsync();
            return author;
        }

        public async Task<Author> RemoveAuthorAsync(int removeId)
        {
            var author = this.GetAuthorAsync(removeId);
            if (author != null)
            {
                _context.Authors.Remove(author.Result);
            }

            await _context.SaveChangesAsync();

            return new Author
            {
                Id = author.Result.Id,
                Name = author.Result.Name,
                Surname = author.Result.Surname,
                DateAdded = author.Result.DateAdded
            };
        }
    }
}
