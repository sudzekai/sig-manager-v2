using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record PhoneNumber : ValueObjectBase, IValueObject<PhoneNumber, string>
    {
        private PhoneNumber() : base(true) { }

        private PhoneNumber(string value) : base(false)
            => Value = value;

        public static PhoneNumber FromValue(string value)
           => new(value);

        public static PhoneNumber Default 
            => new();

        public string Value { get; } = string.Empty;

        public string LastFour
            => Value[^4..];

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.PhoneNumberIsRequired);

                if (Value.Length != 12)
                    throw new AppException(UserObjectErrors.PhoneNumberIsInvalidLength);

                if (!Value.StartsWith("+79") || !Value.Replace("+79", "").All(char.IsDigit))
                    throw new AppException(UserObjectErrors.PhoneNumberIsInvalid);

                return true;
            }
        }
    }
}
