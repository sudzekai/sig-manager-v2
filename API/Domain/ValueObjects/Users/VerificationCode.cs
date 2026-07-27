using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record VerificationCode : ValueObjectBase, IValueObject<VerificationCode, string>
    {
        private VerificationCode() : base(true) { }

        private VerificationCode(string value) : base(false)
            => Value = value;

        public static VerificationCode FromValue(string value)
            => new(value);

        public static VerificationCode Default
            => new();

        public static VerificationCode Empty
            => new("empty");

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (this == Empty)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.VerificationCodeIsRequired);

                if (Value.Length != 6)
                    throw new AppException(UserObjectErrors.VerificationCodeIsInvalidLength);

                return true;
            }
        }
    }
}
