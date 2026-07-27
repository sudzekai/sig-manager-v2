namespace Shared.Types.Errors.ApplicationError.Dictionaries
{
    /// <summary>
    /// Класс определяющий код ошибки
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
    internal static class ErrorCodes
    {
        public const int Unknown = 0;

        public const int Required = 10;
        public const int Invalid = 11;
        public const int InvalidLength = 12;
        public const int InvalidFormat = 13;
        public const int OutOfRange = 14;
        public const int TooSmall = 15;
        public const int TooLarge = 16;

        public const int Unauthorized = 20;
        public const int Forbidden = 21;

        public const int InvalidState = 30;
        public const int Expired = 31;
        public const int Disabled = 32;
        public const int Locked = 33;

        public const int NotFound = 40;

        public const int AlreadyExists = 50;
        public const int Conflict = 51;

        public const int InUse = 60;
        public const int LimitExceeded = 61;

        public const int ExternalServiceError = 70;

        public const int DatabaseError = 80;

        public const int NotImplemented = 90;
    }
}
