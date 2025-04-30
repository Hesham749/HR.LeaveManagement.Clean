using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
public class UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository,
    IAppLogger<UpdateLeaveTypeCommandHandler> logger)
    : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateLeaveTypeValidator(leaveTypeRepository);

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            logger.LogWarning($"Validation errors in update request for {nameof(LeaveType)} - {request.Id}");
            throw new BadRequestException("Invalid Leave type", validationResult);
        }

        var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id) ?? null!;

        leaveType.Name = request.Name;
        leaveType.DefaultDays = request.DefaultDays;

        await leaveTypeRepository.UpdateAsync(leaveType);

        return Unit.Value;
    }
}
