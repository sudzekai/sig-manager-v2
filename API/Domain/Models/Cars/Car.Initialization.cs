using Domain.Models.Base;
using Domain.ValueObjects.Cars;

namespace Domain.Models.Cars
{
    public partial class Car : DomainModelBase
    {
        internal Car(CarId id, Name name, Status status, ControllerModel controllerModel, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Status = status;
            ControllerModel = controllerModel;
            CreatedAt = createdAt;

            _initialized = true;
        }

        internal Car(CarId id, Name name, Status status, ControllerModel controllerModel)
        {
            Id = id;
            Name = name;
            Status = status;
            ControllerModel = controllerModel;

            _initialized = true;
        }

        internal static Car Restore(CarId id, Name name, Status status, ControllerModel controllerModel, DateTime createdAt)
            => new(id, name, status, controllerModel, createdAt);

        public static Car Create(CarId id, Name name, Status status, ControllerModel controllerModel)
            => new(id, name, status, controllerModel);
    }
}
