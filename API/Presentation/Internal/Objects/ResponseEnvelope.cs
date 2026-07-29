using Shared.Types.Exceptions;
using Shared.Utilities.BusinessErrorFactory;

namespace Presentation.Internal.Objects
{
    public class ResponseEnvelope<T>
    {
        public ResponseEnvelope() { }

        public ResponseEnvelope(T? data)
        {
            Success = true;
            Data = data;
        }

        public ResponseEnvelope(Error? error)
        {
            Success = false;
            Error = error;
        }

        public static ResponseEnvelope<T> FromData(T? data) => new(data);

        public static ResponseEnvelope<T> FromError(AppException ex)
        {
            var err = BusinessErrorFactory.ToBusinessException(ex);
            return new(new Error(err.Code, err.Message));
        }

        public static ResponseEnvelope<T> InternalServerError => new(new Error(500, "Внутренняя ошибка сервера"));
        public static ResponseEnvelope<T> NotImplementedError => new(new Error(501, "Функциональность эндпоинта не реализована"));

        public bool Success { get; set; }
        public T? Data { get; set; }
        public Error? Error { get; set; }
    }
}
