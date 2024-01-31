using BookNation.Data;
using BookNation.DTO;
using BookNation.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        [HttpPut("update/{id}")]
        public async Task<ActionResult<AppUser>> Update(int id, RegisterDto userDto)
        {
            var entry = await _context.Users.Where(auth => auth.Id == id).FirstOrDefaultAsync();
    
            entry.UserName = userDto.UserName;
            entry.UserSurname = userDto.UserSurname;
            entry.UserEmail = userDto.UserEmail;
            entry.UserPhone = userDto.UserPhone;

            _context.Users.Update(entry);
            await _context.SaveChangesAsync();

            return new AppUser
            {
                Id = entry.Id,
                UserName = entry.UserName,
                UserSurname = entry.UserSurname,
                UserEmail = entry.UserEmail,
                UserPhone = entry.UserPhone
            };
        }


        
    }
}