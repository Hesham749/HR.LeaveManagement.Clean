using HR.LeaveManagement.Application.Contracts.Presistence;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;
public class LeaveTypeRepository(HrDbContext context)
    : GenericRepository<LeaveType>(context), ILeaveTypeRepository
{
    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return !await _context.leaveTypes.AnyAsync(x => x.Name!.Equals(name));
    }

    public async Task<bool> IsLeaveTypeExists(int id)
    {
        return await _context.leaveTypes.AnyAsync(x => x.Id == id);
    }
}
