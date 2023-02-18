namespace iMed.Infrastructure.Models.RestApi.IDPay;

public enum IDPayTransactionStatus
{
    [Display(Name = "پرداخت انجام نشده است")]
    PaymentUnDone = 1,
    [Display(Name = "پرداخت ناموفق بوده است")]
    PaymentUnSuccess = 2,
    [Display(Name = "خطا رخ داده است")]
    PaymentFailure = 3,
    [Display(Name = "بلوکه شده")]
    PaymentBlock = 4,
    [Display(Name = "برگشت به پرداخت کننده")]
    PaymentReturnToCustomer = 5,
    [Display(Name = "برگشت خورده سیستمی")]
    PaymentReturnToSystem = 6,
    [Display(Name = "انصراف از پرداخت")]
    PaymentCancelByCustomer = 7,
    [Display(Name = "به درگاه پرداخت منتقل شد")]
    PaymentInATM = 8,
    [Display(Name = "در انتظار تایید پرداخت")]
    PaymentWaitForVerify = 10,
    [Display(Name = "پرداخت تایید شده است")]
    PaymentVerified = 100,
    [Display(Name = "پرداخت قبلا تایید شده است")]
    PaymentVerifiedBefore = 101,
    [Display(Name = "به دریافت کننده واریز شد")]
    PaymentSuccess = 200,


}
public class IDPayCallBackRequest
{
    public IDPayTransactionStatus Status { get; set; }
    public string Card_no { get; set; }
    public string Id { get; set; }
    public string Order_id { get; set; }
}