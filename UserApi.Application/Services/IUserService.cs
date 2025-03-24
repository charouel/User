using UserApi.Application.DTOs;
using UserApi.Domain.Entities;

namespace UserApi.Application.Services
{
    public interface IUserService
    {
        public Task<List<User>> GetAllUsersAsync();
        public Task<int> AddUserAsync(UserDto userDto);
        public Task<UserDto> GetUserByIdAsync(int userId);
        public Task<bool> UpdateUserAsync(int id, UserDto userDto);
    }
}
