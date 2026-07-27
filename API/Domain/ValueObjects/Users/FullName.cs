using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record FullName : ValueObjectBase
    {
        public readonly string Value;

        private FullName(string value) 
            => Value = value;
        
        public static FullName FromValue(string value)
            => new(value);

        public override bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.FullNameIsRequired);

                if (Value.Length > 255)
                    throw new AppException(UserObjectErrors.FullNameIsInvalidLength);

                if (Value.Any(char.IsDigit))
                    throw new AppException(UserObjectErrors.FullNameIsInvalid);

                return true;
            }
        }
    }
}
