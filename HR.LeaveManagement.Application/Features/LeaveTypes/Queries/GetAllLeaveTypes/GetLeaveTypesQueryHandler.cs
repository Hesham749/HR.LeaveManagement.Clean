using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
public class GetLeaveTypesQueryHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    : IRequestHandler<GetLeaveTypesQuery, IReadOnlyList<LeaveTypeDto>>
{
    public async Task<IReadOnlyList<LeaveTypeDto>> Handle(GetLeaveTypesQuery request, CancellationToken cancellationToken)
    {
        var leaveTypes = await leaveTypeRepository.GetAsync();

        var result = mapper.Map<IReadOnlyList<LeaveTypeDto>>(leaveTypes);

        return result;
    }
}
