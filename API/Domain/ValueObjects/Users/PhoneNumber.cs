using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record PhoneNumber : ValueObjectBase
    {
        public readonly string Value;
        public readonly string LastFour;

        private PhoneNumber(string value)
        {
            Value = value;
            LastFour = value[^4..];
        }

        public static PhoneNumber FromValue(string value)
           => new(value);

        public override bool IsValid
        {
            get
            {
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
