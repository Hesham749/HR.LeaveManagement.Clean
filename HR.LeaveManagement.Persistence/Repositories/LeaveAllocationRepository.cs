using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository(HrDbContext context)
    : GenericRepository<LeaveAllocation>(context), ILeaveAllocationRepository
{
    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations.AnyAsync(x => x.EmployeeId == userId
        && x.LeaveTypeId == leaveTypeId
        && x.Period == period);
    }

    public async Task<LeaveAllocation?> GetLeaveAllocation(string userId, int leaveTypeId)
    {
        return await _context.LeaveAllocations.Where(x => x.EmployeeId == userId && x.LeaveTypeId == leaveTypeId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        return await _context.LeaveAllocations.Include(x => x.LeaveType)
             .ToListAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        return await _context.LeaveAllocations.Include(x => x.LeaveType)
            .Where(x => x.EmployeeId == userId)
             .ToListAsync();
    }

    public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations.Include(x => x.LeaveType)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();
    }
}
