using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record PasswordHash : ValueObjectBase, IValueObject<PasswordHash, string>
    {
        private PasswordHash() : base(true) { }

        private PasswordHash(string value) : base(false)
            => Value = value;

        public static PasswordHash FromValue(string value)
            => new(value);

        public static PasswordHash Default 
            => new();

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.PasswordIsRequired);

                return true;
            }
        }
    }
}
