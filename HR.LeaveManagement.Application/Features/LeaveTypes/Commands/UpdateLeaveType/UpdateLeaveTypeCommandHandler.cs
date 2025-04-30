using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Presistence;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
public class UpdateLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    : IRequestHandler<UpdateLeaveTypeCommand, Unit>
{
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveTypeToUpdate = await leaveTypeRepository.GetByIdAsync(request.Id);

        if (leaveTypeToUpdate is null) return Unit.Value;

        await leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

        return Unit.Value;
    }
}
