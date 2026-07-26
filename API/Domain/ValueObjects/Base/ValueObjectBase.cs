namespace Domain.ValueObjects.Base
{
    public abstract record ValueObjectBase
    {
        public abstract bool IsValid { get; }
    }
}
