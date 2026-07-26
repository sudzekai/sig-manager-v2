using Domain.Models.Base;
using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;

namespace Domain.Models.Users
{
    public partial class User : DomainModelBase
    {
        private User(
            UserId id,
            Username username,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber,
            PasswordHash passwordHash,
            VerificationCode verificationCode,
            DateTime createdAt,
            RoleId roleId)
        {
            Id = id;
            Username = username;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            VerificationCode = verificationCode;
            CreatedAt = createdAt;
            RoleId = roleId;

            _initialized = true;
        }

        private User(
            Username username,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber,
            PasswordHash passwordHash,
            RoleId roleId)
        {
            Id = UserId.Default;

            Username = username;
            FullName = fullName;
            Email = email;
            PhoneNumber = phoneNumber;
            PasswordHash = passwordHash;
            RoleId = roleId;
            VerificationCode = VerificationCode.Empty;

            CreatedAt = DateTime.Now;

            _initialized = true;
        }

        internal static User Restore(
            UserId id,
            Username username,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber,
            PasswordHash passwordHash,
            VerificationCode verificationCode,
            DateTime createdAt,
            RoleId roleId)
            => new(id,
                username,
                fullName,
                email,
                phoneNumber,
                passwordHash,
                verificationCode,
                createdAt,
                roleId);

        public static User Create(
            Username username,
            FullName fullName,
            Email email,
            PhoneNumber phoneNumber,
            PasswordHash passwordHash,
            RoleId roleId)
            => new(username,
                fullName,
                email,
                phoneNumber,
                passwordHash,
                roleId);
    }
}
