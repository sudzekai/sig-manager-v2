using Shared.Types.Exceptions;
using Shared.Utilities.BusinessErrorFactory;

namespace Presentation.Internal.Objects
{
    internal class ResponseEnvelope
    {
        public ResponseEnvelope(object? data)
        {
            Success = true;
            Data = data;
        }

        public ResponseEnvelope(Error? error)
        {
            Success = false;
            Error = error;
        }

        public static ResponseEnvelope FromData(object? data) => new(data);

        public static ResponseEnvelope FromError(AppException ex)
        {
            var err = BusinessErrorFactory.ToBusinessException(ex);
            return new(new Error(err.Code, err.Message));
        }

        public static ResponseEnvelope InternalServerError => new(new Error(500, "Внутренняя ошибка сервера"));
        public static ResponseEnvelope NotImplementedError => new(new Error(501, "Функциональность эндпоинта не реализована"));

        public bool Success { get; set; }
        public object? Data { get; set; }
        public Error? Error { get; set; }
    }
}
