using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record VerificationCode : ValueObjectBase
    {
        public readonly string Value;

        private VerificationCode(string value)
            => Value = value;

        public static VerificationCode FromValue(string value)
            => new(value);

        public override bool IsValid
        {
            get
            {
                if (this == Empty)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.VerificationCodeIsRequired);

                if (Value.Length != 6)
                    throw new AppException(UserObjectErrors.VerificationCodeIsInvalidLength);

                return true;
            }
        }

        public static readonly VerificationCode Empty = new("empty");
    }
}
