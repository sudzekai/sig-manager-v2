using Domain.Models.Users;
using Domain.ValueObjects.Users;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserId> AddAsync(User user);
        Task<bool> DeleteAsync(UserId id);
        Task<User?> GetAsync(UserId id);
        Task<UserId?> GetByEmailAsync(Email email);
        Task<UserId?> GetByUsernameAsync(Username username);
        Task<UserId?> GetByPhoneNumberAsync(PhoneNumber phoneNumber);
        Task UpdateAsync(User user);
    }
}