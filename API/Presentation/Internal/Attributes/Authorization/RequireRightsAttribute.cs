using Domain.Models.Rights;
using System;

namespace Presentation.Internal.Attributes.Authorization
{

    [AttributeUsage(AttributeTargets.Method)]
    public class RequireRightsAttribute : Attribute
    {
        public Right[] Rights { get; set; }

        public RequireRightsAttribute(Right[] rights)
        {
            Rights = rights;
        }
    }
}
