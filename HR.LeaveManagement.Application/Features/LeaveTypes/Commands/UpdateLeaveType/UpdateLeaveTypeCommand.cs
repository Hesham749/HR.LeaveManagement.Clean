using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
public record UpdateLeaveTypeCommand(int Id, string Name, int DefaultDays) : IRequest<Unit>;
