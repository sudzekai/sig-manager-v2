using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Roles
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
                    throw new AppException(RoleObjectErrors.RoleNameIsRequired);

                if (Value.Length < 5)
                    throw new AppException(RoleObjectErrors.RoleNameIsInvalidTooSmall);

                if (Value.Length > 25)
                    throw new AppException(RoleObjectErrors.RoleNameIsInvalidTooLarge);

                if (Value.Any(char.IsDigit))
                    throw new AppException(RoleObjectErrors.RoleNameIsInvalid);

                return true;
            }
        }
    }
}
