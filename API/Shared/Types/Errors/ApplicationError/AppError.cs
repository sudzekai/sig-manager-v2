using Shared.Internal;
using Shared.Types.Errors.ApplicationError.Dictionaries;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Exceptions;
using Shared.Utilities.BusinessErrorFactory;

namespace Shared.Types.Errors.ApplicationError
{
    /// <summary>
    /// Базовый класс для создания и регистрации экземпляров <see cref="AppError"/>.
    ///
    /// <para><b>Формат ключа:</b></para>
    /// <code>SCOPE.PROPERTY.ERROR</code>
    /// <para>Пример: <c>USER.EMAIL.INVALID_FORMAT</c></para>
    ///
    /// <para><b>Формат числового кода:</b></para>
    /// <code>Scope_Property_Error</code>
    /// <para>Пример: <c>1_04_13</c></para>
    ///
    /// <para><b>Структура числового кода:</b></para>
    /// <list type="bullet">
    /// <item><description><c>Scope</c> — область или сущность.</description></item>
    /// <item><description><c>Property</c> — свойство или группа ошибок.</description></item>
    /// <item><description><c>Error</c> — тип ошибки.</description></item>
    /// </list>
    ///
    /// <para>Все ключи и числовые коды должны быть уникальными, при этом уникальность гарантируется методом <see cref="Create(string, int)"/> </para>
    /// </summary>
    public class AppError : IEquatable<AppError>
    {
        public string Key { get; } = string.Empty;
        public int Code { get; }

        private static HashSet<int> _codes = [];
        private static HashSet<string> _keys = [];

        private AppError(string key, int code)
        {
            Key = key;
            Code = code;
        }

        internal static AppError Create(string key, int code)
        {
            if (!_codes.Add(code))
                throw new AppException(InternalErrors.ErrorCodeAlreadyExists, $"duplicate code: {code}");

            if (!_keys.Add(key))
                throw new AppException(InternalErrors.ErrorCodeAlreadyExists, $"duplicate key: {key}");

            return new(key, code);
        }

        public int GetCodePrefix()
            => Code / 1_000_000;

        public int GetCodeEntity()
            => (Code / 10_000) % 100;

        public int GetCodeProperty()
            => (Code / 100) % 100;

        public int GetCodeSuffix()
            => Code % 100;

        public int GetEntityTypeCode()
            => Key.ToString().First();

        public static bool operator ==(AppError? left, AppError? right)
            => left?.Code == right?.Code;

        public static bool operator !=(AppError? left, AppError? right)
            => left?.Code != right?.Code;

        public bool Equals(AppError? other)
            => other is not null && Code == other.Code;

        public override bool Equals(object? obj)
            => obj is AppError other && Equals(other);

        public override int GetHashCode()
            => Code.GetHashCode();

        public override string ToString()
            => $"{Code}:{Key}";

        public static void PrintAllErrors(TextWriter writer)
        {
            long[] codes = [.. _codes];
            string[] keys = [.. _keys];

            writer.WriteLine($"CODE;KEY;");

            for (int i = 0; i < codes.Length; i++)
                writer.WriteLine($"{codes[i]};{keys[i]}");
        }

        public static void PrintAllErrorsWithBusinessMessage(TextWriter writer)
        {
            int[] codes = [.. _codes];
            string[] keys = [.. _keys];

            writer.WriteLine($"CODE;KEY;HTTP;MESSAGE");

            for (int i = 0; i < codes.Length; i++)
            {
                var ex = BusinessExceptionFactory.ToBusinessException(new AppException(new AppError(keys[i], codes[i])));
                writer.WriteLine($"{codes[i]};{keys[i]};{ex.Code};{ex.Message}");
            }
        }
    }
}
