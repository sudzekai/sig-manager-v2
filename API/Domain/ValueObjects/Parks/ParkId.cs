using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Parks
{
    public record ParkId : ValueObjectBase, IValueObject<ParkId, long>
    {
        private ParkId() : base(true) { }

        private ParkId(long value) : base(false)
            => Value = value;

        public static ParkId FromValue(long value)
            => new(value);
        
        public static ParkId Default 
            => new();

        public long Value { get; } = default;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (Value < 1)
                    throw new AppException(ParkObjectErrors.ParkIdIsToSmall);

                return true;
            }
        }
    }
}
