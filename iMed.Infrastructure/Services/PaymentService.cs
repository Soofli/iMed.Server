using iMed.Repos.Interfaces;

namespace iMed.Infrastructure.Services;

public class PaymentService : IPaymentService
{
    private readonly IRestApiWrapper _restApiWrapper;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly UserManager<User> _userManager;
    private readonly ICurrentUserService _currentUserService;
    private readonly string _baseUrl;
    public PaymentService(IRestApiWrapper restApiWrapper
        ,IOptionsSnapshot<SiteSettings> optionsSnapshot
        ,IRepositoryWrapper repositoryWrapper,
        UserManager<User> userManager,
        ICurrentUserService currentUserService)
    {
        _restApiWrapper = restApiWrapper;
        _repositoryWrapper = repositoryWrapper;
        _userManager = userManager;
        _currentUserService = currentUserService;
        _baseUrl = optionsSnapshot.Value.BaseUrl;
    }
    public async Task<string> CreatePaymentLink(int amount,int orderId,string name,string phone)
    {
        try
        {
            var request = new IDPayCreatePaymentRequest
            {
                Amount = amount,
                Name = name,
                Phone = phone,
                Order_id = orderId,
                Desc = $"پرداخت به کیف پول اپلیکیشن آی مد",
                Callback = $"{_baseUrl}/api/v1/Payment/CompletePayment"
            };
            var res = await _restApiWrapper.IDPayRestApi.CreatePayment(request, "4cd0667a-1e07-40cb-9283-c3c93b798ad1");
            return res.Link;
        }
        catch (ApiException e)
        {
            var exe = await e.GetContentAsAsync<IDPayErrorResponse>();
            if (exe != null)
                throw new AppException(exe.error_message);
            else
                throw new AppException("گرفتن لینک پرداخت با مشکل مواجه شده است");
        }
    }

    public async Task VerifyPayment(string id, string orderId)
    {
        try
        {
            var request = new IDPayVerifyPaymentRequest
            {
                id = id,
                order_id = orderId
            };
            var res = await _restApiWrapper.IDPayRestApi.VerifyPayment(request, "4cd0667a-1e07-40cb-9283-c3c93b798ad1");
            if (res.status == 100)
            {
                int amount = res.amount.ToInt()/10;
                var user = await _userManager.FindByIdAsync(orderId);
                if (user == null)
                    throw new AppException("کاربرمورد نظر پیدا نشد");
                await _repositoryWrapper.SetRepository<Payment>().AddAsync(new Payment
                {
                    UserId = user.Id,
                    Amount = amount,
                    //CardNumber = res.payment.card_no,
                    Description = $"افزایش موجودی کیف پول کاربر {user.FirstName} {user.LastName}",
                    PaymentTime = DateTime.Now,
                    TransactionCode = res.track_id,
                },default);
                user.WalletBalance += amount;
                await _userManager.UpdateAsync(user);
            }
        }
        catch (ApiException e)
        {
            var exe = await e.GetContentAsAsync<IDPayErrorResponse>();
            if (exe != null)
                throw new AppException(exe.error_message);
            else
                throw new AppException("گرفتن لینک پرداخت با مشکل مواجه شده است");
        }
    }
}