using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Products
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
                    throw new AppException(ProductObjectErrors.ProductNameIsRequired);

                if (Value.Length < 5)
                    throw new AppException(ProductObjectErrors.ProductNameIsInvalidTooSmall);

                if (Value.Length > 50)
                    throw new AppException(ProductObjectErrors.ProductNameIsInvalidTooLarge);

                if (Value.Any(char.IsDigit))
                    throw new AppException(ProductObjectErrors.ProductNameIsInvalid);

                return true;
            }
        }
    }
}
