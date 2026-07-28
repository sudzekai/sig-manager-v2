using Domain.ValueObjects.Positions;

namespace Domain.Models.Positions
{
    public partial class Position
    {
        public PositionId Id
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = PositionId.Default;

        public Name Name
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = Name.Default;

        public void ChangeName(string value)
               => Name = Name.FromValue(value);

        public void ChangeName(Name value)
            => Name = value;

        public PricePerHour PricePerHour
        {
            get;
            private set
            {
                if (field == value
                    || !value.IsValid)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = PricePerHour.Default;
    }
}
