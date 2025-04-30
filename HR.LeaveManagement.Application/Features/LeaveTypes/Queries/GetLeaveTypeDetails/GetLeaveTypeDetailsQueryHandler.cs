using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
public class GetLeaveTypeDetailsQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
    : IRequestHandler<GetLeaveTypeDetailsQuery, LeaveTypeDetailsDto?>
{
    public async Task<LeaveTypeDetailsDto?> Handle(GetLeaveTypeDetailsQuery request, CancellationToken cancellationToken)
    {
        var leaveType = await leaveTypeRepository.GetByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(LeaveType), request.Id);

        return mapper.Map<LeaveTypeDetailsDto>(leaveType);
    }
}
