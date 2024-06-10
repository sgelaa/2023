using BookNation.DataAccess.Data;
using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Presenter.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace BookNation.Presenter.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly DataContext context;
        private readonly ITokenService tokenService;

        public AuthenticationController(DataContext context, ITokenService tokenService)
        {
            this.tokenService = tokenService;
            this.context = context;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserEmail))
            {
                return BadRequest("UserEmail taken");
            }

            using var hmac = new HMACSHA512();

            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                UserSurname = registerDto.UserSurname.ToLower(),
                UserEmail = registerDto.UserEmail.ToLower(),
                UserPhone = registerDto.UserPhone,
                DateCreated = DateTime.Now,
                
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return new UserDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await this.context.Users.SingleOrDefaultAsync(x => x.UserEmail == loginDto.Email);

            if (user == null)
            {
                return Unauthorized("inalid username");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("invalid password");
                }
            }

            return new UserDto
            {
                Username = user.UserName,
                Token = tokenService.CreateToken(user)
            };
        }
        private async Task<bool> UserExists(string username)
        {
            return await this.context.Users.AnyAsync(user => user.UserEmail == username.ToLower());
        }
    }
}
