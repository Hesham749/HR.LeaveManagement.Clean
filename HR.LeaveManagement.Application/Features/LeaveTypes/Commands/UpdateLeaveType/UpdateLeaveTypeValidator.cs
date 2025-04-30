using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Presistence;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
public class UpdateLeaveTypeValidator
    : AbstractValidator<UpdateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public UpdateLeaveTypeValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        this._leaveTypeRepository = leaveTypeRepository;



        RuleFor(x => x.Id)
            .MustAsync(LeaveTypeExists);

        RuleFor(x => x.Name)
            .NotEmpty()
            .MaximumLength(70);

        RuleFor(x => x.DefaultDays)
            .LessThan(100)
            .GreaterThanOrEqualTo(1);

        RuleFor(x => x)
            .MustAsync(LeaveTypeNameUnique);



    }

    private async Task<bool> LeaveTypeNameUnique(UpdateLeaveTypeCommand command, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(command.Name);
    }

    private async Task<bool> LeaveTypeExists(int id, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeExists(id);
    }
}
