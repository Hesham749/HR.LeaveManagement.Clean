using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository(HrDbContext context) 
    : GenericRepository<LeaveAllocation>(context), ILeaveAllocationRepository
{
}
