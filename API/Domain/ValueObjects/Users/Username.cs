using Domain.ValueObjects.Base;
using Shared.Types.Errors;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record Username : ValueObjectBase
    {
        public readonly string Value;

        private Username(string value) 
            => Value = value;

        public static Username FromValue(string value)
            => new(value);

        public override bool IsValid
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserErrors.UsernameIsRequired);

                if (Value.Length > 25)
                    throw new AppException(UserErrors.UsernameIsInvalidLength);

                return true;
            }
        }
    }
}
