using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
public record GetLeaveTypeDetailsQuery(int Id) : IRequest<LeaveTypeDetailsDto?>;
