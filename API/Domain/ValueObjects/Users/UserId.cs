using Domain.ValueObjects.Base;
using Shared.Types.Errors;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record UserId : ValueObjectBase
    {
        public readonly long Value;
        private readonly bool _isDefault;

        private UserId(long value, bool isDefault)
        {
            _isDefault = isDefault;
            Value = value;
        }

        public static UserId FromValue(long value)
            => new(value, false);

        public static UserId Default
            => new(0, true);

        public override bool IsValid
        {
            get
            {
                if (_isDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(UserErrors.IdIsInvalid);

                return true;
            }
        }
    }
}
