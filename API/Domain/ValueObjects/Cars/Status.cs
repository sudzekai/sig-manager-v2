using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Cars
{
    public record Status : ValueObjectBase, IValueObject<Status, string>
    {
        private Status() : base(true) { }

        private Status(string value) : base(false)
            => Value = value;

        public static Status FromValue(string value)
            => new(value);

        public static Status Default
            => new();

        public static Status Working
            => new("working");

        public static Status Broken
            => new("broken");

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(CarObjectErrors.CarStatusIsRequired);

                if (Value != Working.Value || Value != Broken.Value)
                    throw new AppException(CarObjectErrors.CarStatusIsInvalid);

                return true;
            }
        }
    }
}
