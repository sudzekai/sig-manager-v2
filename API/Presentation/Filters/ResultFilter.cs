using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Internal.Extensions;
using Presentation.Internal.Objects;

namespace Presentation.Filters
{
    public class ResultFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context) { }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            switch (context.Result)
            {
                case ObjectResult { Value: ResponseEnvelope<object> }:
                    break;

                case OkObjectResult ok:
                    var env1 = ResponseEnvelope<object>.FromData(ok.Value);
                    context.Result = env1.ToOkObjectResult();
                    break;

                case ObjectResult obj when obj.Value is not null:
                    var env2 = ResponseEnvelope<object>.FromData(obj.Value);
                    context.Result = env2.ToOkObjectResult();
                    break;

                case OkResult or NoContentResult or EmptyResult:
                    context.Result = new NoContentResult();
                    break;
            }
        }
    }
}
