using MediatR;
using UserApi.Application.Features.User.Queries;
using UserApi.Application.Services;
using UserApi.Domain.Entities;

namespace UserApi.Application.Handlers
{
    public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserService _userService;
        public GetAllUsersHandler(IUserService userservice)
        {
            _userService = userservice;
        }
        public async Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsersAsync();
        }
    }
}
