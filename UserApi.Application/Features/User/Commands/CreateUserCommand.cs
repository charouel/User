using MediatR;
using UserApi.Application.DTOs;
namespace UserApi.Application.Features.User.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public required UserDto User { get; set; }
    }
}
