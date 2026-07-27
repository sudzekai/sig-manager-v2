namespace Shared.Types.Errors.ApplicationError.Dictionaries
{
    /// <summary>
    /// Класс определяющий ключ ошибки
    /// 
    /// <list type="table">
    /// <listheader>
    /// <term>Код</term>
    /// <description>Тип</description>
    /// </listheader>
    /// <item><term>00</term><description>Unknown</description></item>
    /// <item><term>10</term><description>Required</description></item>
    /// <item><term>11</term><description>Invalid</description></item>
    /// <item><term>12</term><description>Invalid Length</description></item>
    /// <item><term>13</term><description>Invalid Format</description></item>
    /// <item><term>14</term><description>Out Of Range</description></item>
    /// <item><term>15</term><description>Too Small</description></item>
    /// <item><term>16</term><description>Too Large</description></item>
    /// <item><term>20</term><description>Unauthorized</description></item>
    /// <item><term>21</term><description>Forbidden</description></item>
    /// <item><term>30</term><description>Invalid State</description></item>
    /// <item><term>31</term><description>Expired</description></item>
    /// <item><term>32</term><description>Disabled</description></item>
    /// <item><term>33</term><description>Locked</description></item>
    /// <item><term>40</term><description>Not Found</description></item>
    /// <item><term>50</term><description>Already Exists</description></item>
    /// <item><term>51</term><description>Conflict</description></item>
    /// <item><term>60</term><description>In Use</description></item>
    /// <item><term>61</term><description>Limit Exceeded</description></item>
    /// <item><term>70</term><description>External Service Error</description></item>
    /// <item><term>80</term><description>Database Error</description></item>
    /// <item><term>90</term><description>Not Implemented</description></item>
    /// </list>
    /// </summary>
    public class ErrorKeys
    {
        public const string Unknown = "UNKNOWN";

        public const string Required = "REQUIRED";
        public const string Invalid = "INVALID";
        public const string InvalidLength = "INVALID_LENGTH";
        public const string InvalidFormat = "INVALID_FORMAT";
        public const string OutOfRange = "OUT_OF_RANGE";
        public const string TooSmall = "TOO_SMALL";
        public const string TooLarge = "TOO_LARGE";

        public const string Unauthorized = "UNAUTHORIZED";
        public const string Forbidden = "FORBIDDEN";

        public const string InvalidState = "INVALID_STATE";
        public const string Expired = "EXPIRED";
        public const string Disabled = "DISABLED";
        public const string Locked = "LOCKED";

        public const string NotFound = "NOT_FOUND";

        public const string AlreadyExists = "ALREADY_EXISTS";
        public const string Conflict = "CONFLICT";

        public const string InUse = "IN_USE";
        public const string LimitExceeded = "LIMIT_EXCEEDED";

        public const string ExternalServiceError = "EXTERNAL_SERVICE_ERROR";

        public const string DatabaseError = "DATABASE_ERROR";

        public const string NotImplemented = "NOT_IMPLEMENTED";
    }
}
