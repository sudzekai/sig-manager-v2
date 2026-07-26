using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Presentation.Internal.Extensions;
using Presentation.Internal.Objects;
using Shared.Types.Exceptions;
using System;
using System.Linq;

namespace Presentation.Filters
{
    internal class ExceptionsFilter(ILogger<ExceptionsFilter> logger) : IExceptionFilter
    {
        private readonly ILogger<ExceptionsFilter> _logger = logger;

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;

            if (ex is null)
                return;


            if (ex is AppException exception)
            {
                _logger.LogError($"{exception.ErrorCode.Code}: {exception.ErrorCode.Key} {(string.IsNullOrEmpty(exception.Message) ? "" : $"- {exception.Message}")}");

                context.Result = ResponseEnvelope.FromError(exception).ToErroredObjectResult();

                return;
            }

            if (ex is NotImplementedException notImplemented)
            {
                context.Result = ResponseEnvelope.NotImplementedError.ToErroredObjectResult();
                _logger.LogError("{Type}: {Message}\n{Full}", ex.GetType().ToString().Split(".").Last(), ex.Message, ex.ToString());

                return;
            }

            context.Result = ResponseEnvelope.InternalServerError.ToErroredObjectResult();
            _logger.LogError("{Type}: {Message}\n{Full}", ex.GetType().ToString().Split(".").Last(), ex.Message, ex.ToString());
        }
    }
}
