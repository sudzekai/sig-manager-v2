using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record Email : ValueObjectBase
    {
        public readonly string Value;

        private Email(string value) 
            => Value = value;

        public static Email FromValue(string value)
            => new(value);

        public override bool IsValid
        {
            get
            {
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
