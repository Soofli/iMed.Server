namespace iMed.Infrastructure.RestServices;

public interface IDPayRestApi
{
    [Post("/payment")]
    Task<IDPayCreatePaymentResponse> CreatePayment([Body] IDPayCreatePaymentRequest paymentRequest,[Header("X-API-KEY")]string apiKey , [Header("X-SANDBOX")] int isTest = 0);

    [Post("/payment/verify")]
    Task<IDPayVerifyPaymentResponse> VerifyPayment([Body] IDPayVerifyPaymentRequest verifyRequest, [Header("X-API-KEY")] string apiKey, [Header("X-SANDBOX")] int isTest = 0);
}