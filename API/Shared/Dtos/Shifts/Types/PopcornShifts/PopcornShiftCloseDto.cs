using Shared.Dtos.Shifts.Base.CashShifts;
using Shared.Dtos.Shifts.Base.Shifts;

namespace Shared.Dtos.Shifts.Types.PopcornShifts
{
    public record PopcornShiftCloseDto(
        ShiftCloseDto Shift,
        CashShiftCloseDto Cash
    );
}
