using FluentValidation;
using HR.LeaveManagement.Application.Contracts.Presistence;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
public class CreateLeaveTypeValidator : AbstractValidator<CreateLeaveTypeCommand>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public CreateLeaveTypeValidator(ILeaveTypeRepository leaveTypeRepository)
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MustAsync(LeaveTypeNameUnique).WithMessage("Leave type already exists");



        RuleFor(x => x.DefaultDays)
            .GreaterThan(1)
            .LessThan(100);
        this._leaveTypeRepository = leaveTypeRepository;
    }

    private async Task<bool> LeaveTypeNameUnique(string name, CancellationToken token)
    {
        return await _leaveTypeRepository.IsLeaveTypeUnique(name);
    }
}
