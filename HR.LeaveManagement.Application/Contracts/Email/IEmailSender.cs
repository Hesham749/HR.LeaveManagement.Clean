using HR.LeaveManagement.Application.Models;

namespace HR.LeaveManagement.Application.Contracts.Email;
public interface IEmailSender
{
    Task<bool> SendEmailAsync(EmailMessage email);
}
