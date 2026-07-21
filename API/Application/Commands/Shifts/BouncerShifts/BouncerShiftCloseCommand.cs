using Application.Dtos.Shifts.Types.BouncerShifts;

namespace Application.Commands.Shifts.BouncerShifts
{
    public record BouncerShiftCloseCommand(long Id, BouncerShiftCloseDto Dto) : ICommand<BouncerShiftDto>; 
}
