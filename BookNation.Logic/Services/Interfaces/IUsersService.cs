using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;

namespace BookNation.Logic.Services.Interfaces
{
    public interface IUsersService
    {
        Task<AppUser> AddUserAsync(RegisterDto registerDto);

        Task<IEnumerable<AppUser>> GetUsersAsync();

        Task<AppUser> GetUserAsync(int id);

        Task<AppUser> UpdateUserAsync(int id, RegisterDto userDto);

        Task<bool> UserExists(string username);
    }
}