using UserApi.Domain.Entities;

namespace UserApi.Domain.Interface
{
    public interface IUserRepository
    {
        Task<List<User>> GeTAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
    }
}
