using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.Internal.Objects;

namespace Presentation.Internal.Extensions
{
    internal static class ObjectResultBuilder
    {
        public static ObjectResult ToObjectResult(this ResponseEnvelope<object> response, int statusCode) => new(response) { StatusCode = statusCode };

        public static ObjectResult ToCreatedObjectResult(this ResponseEnvelope<object> response) => response.ToObjectResult(StatusCodes.Status201Created);

        public static ObjectResult ToOkObjectResult(this ResponseEnvelope<object> response) => response.ToObjectResult(StatusCodes.Status200OK);

        public static ObjectResult ToErroredObjectResult(this ResponseEnvelope<object> response) => response.ToObjectResult(response.Error is null ? 500 : response.Error.Code);
    }
}
