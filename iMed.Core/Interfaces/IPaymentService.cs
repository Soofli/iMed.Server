namespace iMed.Core.Interfaces;

public interface IPaymentService : IScopedDependency
{
    Task<string> CreatePaymentLink(int amount, int orderId, string name, string phone);
    Task VerifyPayment(string id,string orderId);
}