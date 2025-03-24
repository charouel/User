using UserApi.Application.DTOs;
using UserApi.Domain.Entities;

namespace UserApi.Application
{
    public static class Map
    {
        public static List<UserDto> ListUserMap(List<User> users)
        {
            var listUserDto = new List<UserDto>();
            foreach (var user in users)
            {
                listUserDto.Add(new UserDto { FirstName = user.FirstName, LastName = user.LastName, Email = user.Email });
            }

            return listUserDto;
        }

        public static UserDto UserMap(User? user)
        {
            var userDto = new UserDto { FirstName = user!.FirstName, LastName = user!.LastName, Email = user.Email };
            return userDto;
        }
    }
}
