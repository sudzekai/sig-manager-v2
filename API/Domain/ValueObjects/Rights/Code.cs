using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Rights
{
    public record Code : ValueObjectBase, IValueObject<Code, string>
    {
        private Code() : base(true) { }

        private Code(string value) : base(false)
            => Value = value;

        public static Code FromValue(string value)
            => new(value);

        public static Code Default
            => new();

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(RightObjectErrors.RightCodeIsRequired);

                if (Value.Length < 5)
                    throw new AppException(RightObjectErrors.RightCodeIsInvalidTooSmall);

                if (Value.Length > 25)
                    throw new AppException(RightObjectErrors.RightCodeIsInvalidTooLarge);

                if (Value.Any(char.IsDigit))
                    throw new AppException(RightObjectErrors.RightCodeIsInvalid);

                return true;
            }
        }
    }
}
