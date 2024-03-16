using System.Security.Cryptography;
using System.Text;
using BookNation.DataAccess.Data;
using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookNation.Logic.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DataContext _context;
        public UsersRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<AppUser> AddUserAsync(RegisterDto registerDto)
        {
            var user = new AppUser
            {
                UserName = registerDto.UserName.ToLower(),
                UserSurname = registerDto.UserSurname.ToLower(),
                UserEmail = registerDto.UserEmail.ToLower(),
                UserPhone = registerDto.UserPhone,
                DateCreated = DateTime.Now
            };

              _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return new AppUser
            {
                UserName = user.UserName,
                UserSurname = user.UserSurname,
                UserEmail= user.UserEmail,
                UserPhone = user.UserPhone,
                DateCreated = user.DateCreated
            };

        }

        public async Task<AppUser> GetUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user;
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public async Task<AppUser> UpdateUserAsync(int id, RegisterDto userDto)
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

        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(user => user.UserEmail == username.ToLower());
        }
    }
}