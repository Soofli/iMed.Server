namespace iMed.Core.Interfaces;

public interface ISmsService : IScopedDependency
{
    Task SendVerifyCodeAsync(string phoneNumber, string verifyCode);
    Task SendForgerPasswordAsync(string phoneNumber, string newPassword);
    Task SendSmsAsync(string phoneNumber, string message);
}