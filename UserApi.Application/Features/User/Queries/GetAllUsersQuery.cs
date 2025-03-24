using MediatR;

namespace UserApi.Application.Features.User.Queries
{
    public class GetAllUsersQuery : IRequest<List<Domain.Entities.User>>
    {
    }
}
