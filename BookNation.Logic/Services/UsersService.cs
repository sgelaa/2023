using BookNation.DataAccess.DTO;
using BookNation.DataAccess.Entities;
using BookNation.Logic.Repository.Interfaces;
using BookNation.Logic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookNation.Logic.Interfaces
{
    public class UsersService : IUsersService
    {
        public readonly IUsersRepository _userRepository;

        public UsersService(IUsersRepository userRepository)
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
