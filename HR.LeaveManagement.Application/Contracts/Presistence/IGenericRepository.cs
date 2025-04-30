using HR.LeaveManagement.Domain.Common;

namespace HR.LeaveManagement.Application.Contracts.Presistence;
public interface IGenericRepository<T> where T : BaseEntity
{
    Task<T?> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAsync();
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    void Delete(T entity);
}
