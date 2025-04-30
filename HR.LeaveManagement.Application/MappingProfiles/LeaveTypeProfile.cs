using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.CreateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Commands.UpdateLeaveType;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeaveTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles;
public class LeaveTypeProfile : Profile
{
    public LeaveTypeProfile()
    {
        CreateMap<LeaveTypeDto, LeaveType>().ReverseMap();
        CreateMap<LeaveTypeDetailsDto, LeaveType>();
        CreateMap<CreateLeaveTypeCommand, LeaveType>();
        CreateMap<UpdateLeaveTypeCommand, LeaveType>();
    }
}
