using MediatR;
using UserApi.Application.Features.User.Commands;
using UserApi.Application.Services;

namespace UserApi.Application.Handlers
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, bool>
    {
        private readonly IUserService _userService;

        public UpdateUserCommandHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var existingUser = await _userService.GetUserByIdAsync(request.Id);

            if (existingUser == null)
            {
                return false; // L'utilisateur n'existe pas
            }

            // Mise à jour des champs
            existingUser.FirstName = request.UserDto.FirstName;
            existingUser.LastName = request.UserDto.LastName;
            existingUser.Email = request.UserDto.Email;

            return await _userService.UpdateUserAsync(request.Id, existingUser);
        }
    }
}
