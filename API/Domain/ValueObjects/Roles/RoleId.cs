using Domain.ValueObjects.Base;
using Shared.Types.Errors;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Roles
{
    public record RoleId : ValueObjectBase
    {
        public readonly long Value;
        private readonly bool _isDefault;

        private RoleId(long value, bool isDefault)
        {
            _isDefault = isDefault;
            Value = value;
        }

        public static RoleId FromValue(long value)
            => new(value, false);

        public static RoleId Default
            => new(0, true);

        public override bool IsValid
        {
            get
            {
                if (_isDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(RoleErrors.IdIsInvalid);

                return true;
            }
        }
    }
}
