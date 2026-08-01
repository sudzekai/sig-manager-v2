using Shared.Types.Errors.Dictionaries.Entities;
using Shared.Types.Errors.Dictionaries.Internals;
using Shared.Types.Errors.Dictionaries.Objects;

namespace Shared.Types.Errors.Dictionaries
{
    public class ErrorDictionariesChecker
    {
        public static void Check()
        {
            EntityErrors.Initialize();

            InternalErrors.Initialize();

            CarObjectErrors.Initialize();
            ParkObjectErrors.Initialize();
            PositionObjectErrors.Initialize();
            ProductObjectErrors.Initialize();
            RightObjectErrors.Initialize();
            RoleObjectErrors.Initialize();
            UserObjectErrors.Initialize();
        }
    }
}
