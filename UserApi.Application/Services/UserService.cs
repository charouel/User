using UserApi.Application.DTOs;
using UserApi.Domain.Entities;
using UserApi.Domain.Interface;

namespace UserApi.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<List<User>> GetAllUsersAsync()
        {
            var users = await _userRepository.GeTAllAsync();
            return users;
        }

        public async Task<int> AddUserAsync(UserDto userDto)
        {
            var user = new User { FirstName = userDto.FirstName, LastName = userDto.LastName, Email = userDto.Email };
            await _userRepository.AddAsync(user);
            return user.Id;
        }

        public async Task<UserDto> GetUserByIdAsync(int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var userDto = Map.UserMap(user);
            return userDto;

        }

        public async Task<bool> UpdateUserAsync(int id, UserDto userDto)
        {
            try
            {
                // Récupérer l'utilisateur existant depuis la base de données
                var existingUser = await _userRepository.GetByIdAsync(id);

                if (existingUser == null)
                {
                    // Utilisateur non trouvé
                    return false;
                }

                // Mettre à jour les propriétés de l'utilisateur
                existingUser.FirstName = userDto.FirstName;
                existingUser.LastName = userDto.LastName;
                existingUser.Email = userDto.Email;

                // Sauvegarder les modifications dans la base de données
                await _userRepository.UpdateAsync(existingUser);

                return true;
            }
            catch (Exception)
            {
                // Gérer l'exception si nécessaire
                return false;
            }
        }

    }
}
