using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Rights
{
    public record RightId : ValueObjectBase, IValueObject<RightId, long>
    {
        private RightId() : base(false) { }

        private RightId(long value) : base(false)
            => Value = value;

        public static RightId FromValue(long value)
            => new(value);

        public static RightId Default
            => new();

        public long Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(RightObjectErrors.RightIdIsToSmall);

                return true;
            }
        }
    }
}
