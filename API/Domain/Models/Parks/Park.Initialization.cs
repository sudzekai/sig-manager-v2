using Domain.Models.Base;
using Domain.ValueObjects.Parks;

namespace Domain.Models.Parks
{
    public partial class Park : DomainModelBase
    {
        private Park(Name name)
        {
            Name = name;

            _initialized = true;
        }

        private Park(ParkId id, Name name)
        {
            Id = id;
            Name = name;

            _initialized = true;
        }

        internal static Park Restore(ParkId id, Name name)
            => new(id, name);
        
        public static Park Create(Name name)
            => new(name);
    }
}
