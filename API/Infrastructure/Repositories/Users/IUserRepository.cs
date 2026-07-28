using Domain.Models.Users;
using Domain.ValueObjects.Users;

namespace Infrastructure.Repositories.Users
{
    public interface IUserRepository
    {
        Task<UserId> AddAsync(User user);
        Task<bool> DeleteAsync(UserId id);
        Task<User?> GetAsync(UserId id);
        Task<UserId?> GetIdByEmailAsync(Email email);
        Task<UserId?> GetIdByUsernameAsync(Username username);
        Task<UserId?> GetIdByPhoneNumberAsync(PhoneNumber phoneNumber);
        Task UpdateAsync(User user);
    }
}