using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Presistence;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IReadOnlyList<T>> GetAsync();
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task Delete(T entity);
}
