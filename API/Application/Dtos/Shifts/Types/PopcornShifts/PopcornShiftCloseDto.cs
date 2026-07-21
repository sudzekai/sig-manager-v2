using Application.Dtos.Shifts.Base.CashShifts;
using Application.Dtos.Shifts.Base.Shifts;

namespace Application.Dtos.Shifts.Types.PopcornShifts
{
    public record PopcornShiftCloseDto(
        ShiftCloseDto Shift,
        CashShiftCloseDto Cash
    );
}
