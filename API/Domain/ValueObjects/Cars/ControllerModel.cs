using Domain.ValueObjects.Base;
using Shared.Types.Errors.Dictionaries.Objects;
using Shared.Types.Exceptions;

namespace Domain.ValueObjects.Cars
{
    public record ControllerModel : ValueObjectBase, IValueObject<ControllerModel, string>
    {
        private ControllerModel() : base(true) { }

        private ControllerModel(string value) : base(false)
            => Value = value;

        public static ControllerModel FromValue(string value)
            => new(value);

        public static ControllerModel Default
            => new();

        public string Value { get; } = string.Empty;

        public bool IsValid
        {
            get
            {
                if (IsDefault)
                    return true;

                if (string.IsNullOrWhiteSpace(Value))
                    throw new AppException(CarObjectErrors.CarControllerModelIsRequired);

                if (Value.Length < 5)
                    throw new AppException(CarObjectErrors.CarControllerModelIsInvalidTooSmall);

                if (Value.Length > 50)
                    throw new AppException(CarObjectErrors.CarControllerModelIsInvalidTooLarge);

                return true;
            }
        }
    }
}
