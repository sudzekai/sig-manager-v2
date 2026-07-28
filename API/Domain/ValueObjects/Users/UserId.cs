using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Users
{
    public record UserId : ValueObjectBase, IValueObject<UserId, long>
    {
        private UserId() : base(false) { }

        private UserId(long value) : base(false)
            => Value = value;

        public static UserId FromValue(long value)
            => new(value);

        public static UserId Default
            => new();

        public long Value { get; } = default;

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
