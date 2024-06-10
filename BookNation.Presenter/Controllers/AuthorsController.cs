using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookNation.Presenter.Controllers
{
    public class AuthorsController : BaseApiController
    {

        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Author>>> GetAuthors()
        {
            return Ok(await _authorService.GetAuthorsAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> GetAuthorId(int id)
        {
            try
            {
                var author = await _authorService.GetAuthorAsync(id);
                return Ok(author);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("Add")]
        public async Task<ActionResult<Author>> Add(AuthorDto authorDto)
        {
            return Created("new author created.", await _authorService.AddAuthorAsync(authorDto));
        }

        [HttpPut("Update/{updateId}")]
        public async Task<ActionResult<Author>> Update(int updateId, AuthorDto authorDto)
        {
            if (await _authorService.GetAuthorAsync(updateId) != null)
            {
                return Ok(await _authorService.UpdateAuthorAsync(updateId, authorDto));
            }
            else
            {
                return BadRequest("Author with provided Id not found");
            }
        }

        [HttpDelete("Remove/{removeId}")]
        public async Task<ActionResult<Author>> RemoveId(int removeId)
        {
            return Ok(await _authorService.RemoveAuthorAsync(removeId));
        }
    }
}

