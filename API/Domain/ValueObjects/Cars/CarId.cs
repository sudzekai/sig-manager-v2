using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Cars
{
    public record CarId : ValueObjectBase, IValueObject<CarId, long>
    {
        private CarId() : base(true) { }

        private CarId(long value) : base(false)
            => Value = value;

        public static CarId FromValue(long value)
            => new(value);

        public static CarId Default
            => new();

        public long Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(CarObjectErrors.CarIdIsToSmall);

                return true;
            }
        }
    }
}
