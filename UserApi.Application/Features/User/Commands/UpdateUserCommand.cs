using MediatR;
using UserApi.Application.DTOs;

namespace UserApi.Application.Features.User.Commands
{
    public class UpdateUserCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public UserDto UserDto { get; set; }

        public UpdateUserCommand(int id, UserDto userDto)
        {
            Id = id;
            UserDto = userDto;
        }
    }
}
