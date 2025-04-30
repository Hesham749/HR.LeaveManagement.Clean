namespace HR.LeaveManagement.Application.Contracts.Logging;
public interface IAppLogger<T>
{
    void LogInFormation(string message);
    void LogWarning(string message);
}
