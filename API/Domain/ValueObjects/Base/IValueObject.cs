namespace Domain.ValueObjects.Base
{
    public interface IValueObject<TSelf, T>
    {
        public static abstract TSelf FromValue(T value);

        public static abstract TSelf Default { get; }

        public T Value { get; }

        public bool IsValid { get; }
    }
}
