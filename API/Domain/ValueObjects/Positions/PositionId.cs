using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Positions
{
    public record PositionId : ValueObjectBase, IValueObject<PositionId, long>
    {
        private PositionId() : base(true) { }

        private PositionId(long value) : base(false)
            => Value = value;

        public static PositionId FromValue(long value)
            => new(value);
        
        public static PositionId Default 
            => new();

        public long Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(PositionObjectErrors.PositionIdIsToSmall);

                return true;
            }
        }
    }
}
