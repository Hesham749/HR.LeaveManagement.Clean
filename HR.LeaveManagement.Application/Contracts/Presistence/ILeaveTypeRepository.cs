using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Presistence;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);
    Task<bool> IsLeaveTypeExists(int id);
}
