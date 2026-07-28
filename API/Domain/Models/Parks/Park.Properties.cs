using Domain.ValueObjects.Parks;

namespace Domain.Models.Parks
{
    public partial class Park
    {
        public ParkId Id
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
        } = ParkId.Default;

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
    }
}
