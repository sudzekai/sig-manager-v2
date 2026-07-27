using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record Username : ValueObjectBase, IValueObject<Username, string>
    {
        private Username() : base(false) { }

        private Username(string value) : base(false)
            => Value = value;

        public static Username FromValue(string value)
            => new(value);

        public static Username Default
            => new();

        public string Value { get; } = string.Empty;
        
        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.UsernameIsRequired);

                if (Value.Length > 25)
                    throw new AppException(UserObjectErrors.UsernameIsInvalidLength);

                return true;
            }
        }
    }
}
