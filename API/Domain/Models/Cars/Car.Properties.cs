using Domain.ValueObjects.Cars;

namespace Domain.Models.Cars
{
    public partial class Car
    {
        public CarId Id
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
        } = CarId.Default;

        public void ChangeId(long value)
            => Id = CarId.FromValue(value);

        public void ChangeId(CarId value)
            => Id = value;

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

        public Status Status
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
        } = Status.Default;

        public void ChangeStatus(string value)
            => Status = Status.FromValue(value);

        public void ChangeStatus(Status value)
            => Status = value;

        public ControllerModel ControllerModel
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
        } = ControllerModel.Default;

        public void ChangeControllerModel(string value)
            => ControllerModel = ControllerModel.FromValue(value);

        public void ChangeControllerModel(ControllerModel value)
            => ControllerModel = value;

        public DateTime CreatedAt
        {
            get;
            private set
            {
                if (field == value)
                    return;

                field = value;

                OnPropertyChanged();
            }
        } = default;
    }
}
