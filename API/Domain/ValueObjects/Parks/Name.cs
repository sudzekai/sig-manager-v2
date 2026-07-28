using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Parks
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

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault) 
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(ParkObjectErrors.ParkNameIsRequired);

                if (Value.Length < 5)
                    throw new AppException(ParkObjectErrors.ParkNameIsInvalidTooSmall);

                if (Value.Length > 50)
                    throw new AppException(ParkObjectErrors.ParkNameIsInvalidTooLarge);

                if (Value.Any(char.IsDigit))
                    throw new AppException(ParkObjectErrors.ParkNameIsInvalid);

                return true;
            }
        }
    }
}
