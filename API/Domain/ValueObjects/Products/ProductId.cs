using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Products
{
    public record ProductId : ValueObjectBase, IValueObject<ProductId, long>
    {
        private ProductId() : base(true) { }

        private ProductId(long value) : base(false)
            => Value = value;

        public static ProductId FromValue(long value)
            => new(value);

        public static ProductId Default
            => new();

        public long Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(ProductObjectErrors.ProductIdIsToSmall);

                return true;
            }
        }
    }
}
