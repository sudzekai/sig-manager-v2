using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record FullName : ValueObjectBase, IValueObject<FullName, string>
    {
        private FullName() : base(true) { }

        private FullName(string value) : base(false)
            => Value = value;
        
        public static FullName FromValue(string value)
            => new(value);
        
        public static FullName Default 
            => new();

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(UserObjectErrors.FullNameIsRequired);

                if (Value.Length < 2)
                    throw new AppException(UserObjectErrors.FullNameIsInvalidTooSmall);

                if (Value.Length > 255)
                    throw new AppException(UserObjectErrors.FullNameIsInvalidTooLarge);

                if (Value.Any(char.IsDigit))
                    throw new AppException(UserObjectErrors.FullNameIsInvalid);

                return true;
            }
        }
    }
}
