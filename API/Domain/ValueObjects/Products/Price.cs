using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Products
{
    public record Price : ValueObjectBase, IValueObject<Price, decimal>
    {
        private Price() : base(true) { }

        private Price(decimal value) : base(false)
            => Value = value;

        public static Price FromValue(decimal value)
            => new(value);

        public static Price Default
            => new();

        public decimal Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 0)
                    throw new AppException(ProductObjectErrors.ProductPriceIsInvalidTooSmall);

                if (Value > 99999999.99m)
                    throw new AppException(ProductObjectErrors.ProductPriceIsInvalidTooLarge);

                return true;
            }
        }
    }
}
