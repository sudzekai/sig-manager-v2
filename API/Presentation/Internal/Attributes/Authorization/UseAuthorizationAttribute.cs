using System;

namespace Presentation.Internal.Attributes.Authorization
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class UseAuthorizationAttribute : Attribute;
}
