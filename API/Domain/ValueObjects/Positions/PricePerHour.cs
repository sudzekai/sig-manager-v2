using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Positions
{
    public record PricePerHour : ValueObjectBase, IValueObject<PricePerHour, decimal>
    {
        private PricePerHour() : base(true) { }

        private PricePerHour(decimal value) : base(false)
            => Value = value;

        public static PricePerHour FromValue(decimal value)
            => new(value);
        
        public static PricePerHour Default
            => new();

        public decimal Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(UserObjectErrors.UserIdIsToSmall);

                return true;
            }
        }
    }
}
