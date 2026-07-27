namespace Domain.ValueObjects.Base
{
    public abstract record ValueObjectBase
    {
        public bool IsDefault { get; }

        public ValueObjectBase(bool isDefault)
        {
            IsDefault = isDefault;
        }
    }
}
