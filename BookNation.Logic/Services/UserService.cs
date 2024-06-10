using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using BookNation.Logic.Services.Interfaces;

namespace BookNation.Logic.Interfaces
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<AppUser> AddUserAsync(RegisterDto registerDto)
        {
            return await _userRepository.AddUserAsync(registerDto);
        }

        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _userRepository.GetUserAsync(id);
        }

        public async Task<IEnumerable<AppUser>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<AppUser> UpdateUserAsync(int id, RegisterDto userDto)
        {
            return await _userRepository.UpdateUserAsync(id, userDto);
        }

        public async Task<bool> UserExists(string username) { 
            return await _userRepository.UserExists(username);
        }
    }
}
