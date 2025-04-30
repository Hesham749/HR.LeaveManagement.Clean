using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveRequestRepository(HrDbContext context)
    : GenericRepository<LeaveRequest>(context), ILeaveRequestRepository
{
    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
    {
        return await _context.LeaveRequests
            .Include(x => x.LeaveType)
            .ToListAsync();
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string UserId)
    {
        return await _context.LeaveRequests
            .Where(x => x.RequestingEmployeeId == UserId)
           .Include(x => x.LeaveType)
           .ToListAsync();
    }

    public async Task<LeaveRequest?> GetLeaveRequestWithDetails(int id)
    {
        return await _context.LeaveRequests
           .Where(x => x.Id == id)
          .Include(x => x.LeaveType)
          .FirstOrDefaultAsync();
    }
}