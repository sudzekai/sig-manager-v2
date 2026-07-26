using Domain.ValueObjects.Roles;
using Domain.ValueObjects.Users;

namespace Domain.Models.Users
{
    public partial class User
    {
        public UserId Id
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public RoleId RoleId
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangeRoleId(long value)
            => RoleId = RoleId.FromValue(value);
        public void ChangeRoleId(RoleId value)
            => RoleId = value;

        public Username Username
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangeUsername(string value)
            => Username = Username.FromValue(value);

        public void ChangeUsername(Username value)
            => Username = value;

        public FullName FullName
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangeFullName(string value)
            => FullName = FullName.FromValue(value);

        public void ChangeFullName(FullName value)
            => FullName = value;

        public Email Email
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangeEmail(string value)
            => Email = Email.FromValue(value);

        public void ChangeEmail(Email value)
            => Email = value;

        public PhoneNumber PhoneNumber
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangePhoneNumber(string value)
            => PhoneNumber = PhoneNumber.FromValue(value);

        public void ChangePhoneNumber(PhoneNumber value)
            => PhoneNumber = value;

        public PasswordHash PasswordHash
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangePasswordHash(string value)
            => PasswordHash = PasswordHash.FromValue(value);

        public void ChangePasswordHash(PasswordHash value)
            => PasswordHash = value;


        public VerificationCode VerificationCode
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }

        public void ChangeVerificationCode(string value)
            => VerificationCode = VerificationCode.FromValue(value);

        public void ChangeVerificationCode(VerificationCode value)
            => VerificationCode = value;

        public void SetVerificationCodeEmpty()
            => VerificationCode = VerificationCode.Empty;

        public DateTime CreatedAt
        {
            get;
            private set
            {
                if (field == value)
                    return;

                field = value;

                OnPropertyChanged();
            }
        }
    }
}