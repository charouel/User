using MediatR;
using UserApi.Application.DTOs;

namespace UserApi.Application.Features.User.Queries
{
    public class GetUserByIdQuery : IRequest<UserDto>
    {
        public int Id { get; set; }
    }
}
