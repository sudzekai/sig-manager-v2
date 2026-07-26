using Domain.Models.Users;
using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;
using Infrastructure.Context;
using MySql.Data.MySqlClient;
using SqlKata;
using System.Data;

namespace Infrastructure.Repositories.Users
{
    public class UserRepository(ISigDbContext db) : IUserRepository
    {
        public async Task<UserId> AddAsync(User user)
        {
            var query = new Query("users")
                .AsInsert(new
                {
                    role_id = user.RoleId.Value,
                    username = user.Username.Value,
                    email = user.Email.Value,
                    password_hash = user.PasswordHash.Value,
                    full_name = user.FullName.Value,
                    phone_number = user.PhoneNumber.Value,
                    phone_number_last_four = user.PhoneNumber.LastFour,
                    verification_code = user.VerificationCode.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return UserId.FromValue((int)((MySqlCommand)command).LastInsertedId);
        }

        public async Task<bool> DeleteAsync(UserId id)
        {
            var query = new Query("users")
                .AsDelete()
                .Where(new
                {
                    id = id.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            var affected = await command.ExecuteNonQueryAsync();

            return affected > 0;
        }

        public async Task<User?> GetAsync(UserId id)
        {
            var query = new Query("users")
                .Select(
                    "username",
                    "email",
                    "password_hash",
                    "full_name",
                    "phone_number",
                    "verification_code",
                    "created_at",
                    "role_id"
                )
                .Where(new
                {
                    id = id.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
                return User.Restore(
                    id,
                    Username.FromValue(reader.GetString("username")),
                    FullName.FromValue(reader.GetString("full_name")),
                    Email.FromValue(reader.GetString("email")),
                    PhoneNumber.FromValue(reader.GetString("phone_number")),
                    PasswordHash.FromValue(reader.GetString("password_hash")),
                    VerificationCode.FromValue(reader.GetString("verification_code")),
                    reader.GetDateTime("created_at"),
                    RoleId.FromValue(reader.GetInt64("role_id"))
                );

            return null;
        }

        public async Task<UserId?> GetByEmailAsync(Email email)
        {
            var query = new Query("users")
                .Select("id")
                .Where(new
                {
                    email = email.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return
                idObj is null ? null
                : UserId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task<UserId?> GetByPhoneNumberAsync(PhoneNumber phoneNumber)
        {
            var query = new Query("users")
                .Select("id")
                .Where(new
                {
                    phone_number = phoneNumber.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return
                idObj is null ? null
                : UserId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task<UserId?> GetByUsernameAsync(Username username)
        {
            var query = new Query("users")
                .Select("id")
                .Where(new
                {
                    username = username.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            var idObj = await command.ExecuteScalarAsync();

            return
                idObj is null ? null
                : UserId.FromValue(Convert.ToInt64(idObj));
        }

        public async Task UpdateAsync(User user)
        {
            var query = new Query("users")
                .AsUpdate(new
                {
                    role_id = user.RoleId.Value,
                    username = user.Username.Value,
                    email = user.Email.Value,
                    password_hash = user.PasswordHash.Value,
                    full_name = user.FullName.Value,
                    phone_number = user.PhoneNumber.Value,
                    phone_number_last_four = user.PhoneNumber.LastFour,
                    verification_code = user.VerificationCode.Value
                })
                .Where(new
                {
                    id = user.Id.Value
                });

            await using var command = await db.CreateCommandAsync(query);
            await command.ExecuteNonQueryAsync();
        }
    }
}
