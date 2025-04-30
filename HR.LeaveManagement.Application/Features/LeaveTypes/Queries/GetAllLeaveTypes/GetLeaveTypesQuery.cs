using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
public record GetLeaveTypesQuery : IRequest<IReadOnlyList<LeaveTypeDto>>;
