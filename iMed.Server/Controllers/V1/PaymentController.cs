using iMed.Core.Interfaces;
using iMed.Infrastructure.Models.RestApi.IDPay;

namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PaymentController : BaseController
{

    private readonly IWalletService _walletService;
    private readonly IPaymentService _paymentService;
    private readonly ILogger<PaymentController> _logger;

    public PaymentController(IWalletService walletService,IPaymentService paymentService,ILogger<PaymentController> logger)
    {
        _walletService = walletService;
        _paymentService = paymentService;
        _logger = logger;
    }
    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> PaymentPage()
    {
        return RedirectToPage("/CallbackPaymentPage",new { successful = true });
    }
    [HttpPost("[action]")]
    [AllowAnonymous]
    public async Task<IActionResult> CompletePayment([FromForm] IDPayCallBackRequest callBackRequest)
    {
        try
        {
            if (callBackRequest.Status == IDPayTransactionStatus.PaymentWaitForVerify)
                await _paymentService.VerifyPayment(callBackRequest.Id, callBackRequest.Order_id);
            else
                throw new AppException(callBackRequest.Status.ToDisplay());

            return RedirectToPage("/CallbackPaymentPage", new { successful = true });
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return RedirectToPage("/CallbackPaymentPage", new { successful = false });
        }
    }
}