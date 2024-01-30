using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BookNation.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly DataContext _context;

        public AuthorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Author>>> GetProducts()
        {
            var products = await _context.Authors.ToListAsync();
            return products;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetCategoryDetail(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            return author;
        }

        [HttpGet("allof/{productId}")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAllAuthorsForId(int productId)
        {
            var authors = await _context.Authors.Where(auth => auth.ProductId == productId).ToListAsync();
            return authors;
        }

        [HttpPost("add")]
        public async Task<ActionResult<Author>> Add(AuthorDto authorDto)
        {
            if (await AuthorExists(authorDto.Name, authorDto.Surname, authorDto.ProductId))
            {
                return BadRequest("author already exists");
            }

            var author = new Author
            {
                Name = authorDto.Name,
                Surname = authorDto.Surname,
                ProductId = authorDto.ProductId
            };

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new Author
            {
                Id = author.Id,
                Name = author.Name,
                Surname = author.Surname,
                ProductId = author.ProductId
            };
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<Author>> Update(int id, AuthorDto authorDto)
        {
            var entry = await _context.Authors.Where(auth => auth.Id == id).FirstOrDefaultAsync();
    
            entry.Name = authorDto.Name;
            entry.Surname = authorDto.Surname;
            entry.ProductId = authorDto.ProductId;

            _context.Authors.Update(entry);
            await _context.SaveChangesAsync();

            return new Author
            {
                Id = entry.Id,
                Name = entry.Name,
                Surname = entry.Surname,
                ProductId = entry.ProductId
            };
        }

        [HttpDelete("removeId")]
        public async Task<ActionResult<AuthorDto>> RemoveId(int removeId)
        {
            if (removeId == 0)
            {
                return BadRequest("Please enter a positive id");
            }

            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == removeId);

            if (author == null)
            {
                return BadRequest("Author with provided id does not exist.");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Name = author.Name,
                Surname = author.Surname
            };
        }

        [HttpDelete("remove")]
        public async Task<ActionResult<AuthorDto>> Remove(AuthorDto authorDto)
        {
            if (authorDto.Name.IsNullOrEmpty() || authorDto.Surname.IsNullOrEmpty())
            {
                return BadRequest("Please enter a valid author object");
            }

            var author = await _context.Authors.FirstOrDefaultAsync(auth => auth.Name == authorDto.Name
            && auth.Surname == authorDto.Surname);

            if (author == null)
            {
                return BadRequest("Author with provided details does not exist.");
            }

            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return new AuthorDto
            {
                Name = author.Name,
                Surname = author.Surname
            };
        }

        private async Task<bool> AuthorExists(string name, string surname, int productId)
        {
            return await _context.Authors.AnyAsync(auth => auth.Name.ToLower() == name.ToLower()
            && auth.Surname.ToLower() == surname.ToLower() && auth.ProductId == productId);
        }
    }
}
