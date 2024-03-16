using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookNation.Presenter.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetAll()
        {
            return Ok(await _usersService.GetUsersAsync());
        }


        [HttpPost("Add")]
        public async Task<ActionResult<AppUser>> AddUser(RegisterDto registerDto)
        {
            if (await _usersService.UserExists(registerDto.UserEmail))
            {
                return BadRequest("user email already taken");
            }

            return Ok(await _usersService.AddUserAsync(registerDto));
        }

        // if (await UserExists(registerDto.UserEmail))
        // {
        //     return BadRequest("UserEmail taken");
        // }
    }

}