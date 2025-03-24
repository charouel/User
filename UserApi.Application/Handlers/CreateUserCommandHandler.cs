using MediatR;
using UserApi.Application.Features.User.Commands;
using UserApi.Application.Services;

namespace UserApi.Application.Handlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private readonly IUserService _userService;

        public CreateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.AddUserAsync(request.User);
        }
    }
}
