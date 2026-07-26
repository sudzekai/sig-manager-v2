namespace Shared.Types.Errors
{
    public class ErrorCode : IEquatable<ErrorCode>
    {
        public string Key { get; } = string.Empty;
        public int Code { get; }

        private ErrorCode(string key, int code)
        {
            Key = key;
            Code = code;
        }

        internal static ErrorCode Create(string key, int code)
            => new(key, code);

        public string GetPrefix()
        {
            var index = Key.IndexOf('.');
            return index == -1 ? Key : Key[..index];
        }

        public int GetEntityTypeCode()
            => Key.ToString().First();

        public static bool operator ==(ErrorCode? left, ErrorCode? right)
            => left?.Code == right?.Code;

        public static bool operator !=(ErrorCode? left, ErrorCode? right)
            => left?.Code != right?.Code;

        public bool Equals(ErrorCode? other)
            => other is not null && Code == other.Code;

        public override bool Equals(object? obj)
            => obj is ErrorCode other && Equals(other);

        public override int GetHashCode()
            => Code.GetHashCode();

        public override string ToString()
            => $"{Code}:{Key}";
    }
}
