using Domain.Models.Base;
using Domain.ValueObjects.Positions;

namespace Domain.Models.Positions
{
    public partial class Position : DomainModelBase
    {
        private Position(Name name, PricePerHour pricePerHour)
        {
            Name = name;
            PricePerHour = pricePerHour;

            _initialized = true;
        }

        private Position(PositionId id, Name name, PricePerHour pricePerHour)
        {
            Id = id;
            Name = name;
            PricePerHour = pricePerHour;

            _initialized = true;
        }

        internal static Position Restore(PositionId id, Name name, PricePerHour pricePerHour)
            => new(id, name, pricePerHour);

        public static Position Create(Name name, PricePerHour pricePerHour)
            => new(name, pricePerHour);
    }
}
