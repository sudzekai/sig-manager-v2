using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record Email : ValueObjectBase, IValueObject<Email, string>
    {
        private Email() : base(true) { }

        private Email(string value) : base(false)
        => Value = value;

        public static Email FromValue(string value)
            => new(value);

        public static Email Default 
            => new();

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.EmailIsRequired);

                if (Value.Length < 5)
                    throw new AppException(UserObjectErrors.EmailIsInvalidLength);

                if (Value.Length > 255)
                    throw new AppException(UserObjectErrors.EmailIsInvalidLength);

                return true;
            }
        }
    }
}
