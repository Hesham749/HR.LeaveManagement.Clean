using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Commands.DeleteLeaveType;
public record DeleteLeaveTypeCommand(int Id) : IRequest<Unit>;
