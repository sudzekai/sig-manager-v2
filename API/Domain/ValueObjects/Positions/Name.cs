using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Positions
{
    public record Name : ValueObjectBase, IValueObject<Name, string>
    {
        private Name() : base(true) { }

        private Name(string value) : base(false)
            => Value = value;

        public static Name FromValue(string value)
            => new(value);

        public static Name Default
            => new();

        public string Value { get; } = String.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault) 
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(PositionObjectErrors.PositionNameIsRequired);

                if (Value.Length < 5)
                    throw new AppException(PositionObjectErrors.PositionNameIsInvalidTooSmall);

                if (Value.Length > 50)
                    throw new AppException(PositionObjectErrors.PositionNameIsInvalidTooLarge);

                if (Value.Any(char.IsDigit))
                    throw new AppException(PositionObjectErrors.PositionNameIsInvalid);

                return true;
            }
        }
    }
}
