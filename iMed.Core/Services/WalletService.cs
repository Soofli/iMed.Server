namespace iMed.Core.Services;

public class WalletService : IWalletService
{
    private readonly UserManager<User> _userManager;
    private readonly ICurrentUserService _currentUserService;
    private readonly IPaymentService _paymentService;

    public WalletService(UserManager<User> userManager,ICurrentUserService currentUserService,IPaymentService paymentService)
    {
        _userManager = userManager;
        _currentUserService = currentUserService;
        _paymentService = paymentService;
    }
    public async Task<IncreaseInventoryResponseDto> IncreaseInventoryAsync(int amount)
    {

        var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
        if (user == null)
            throw new AppException("کاربرمورد نظر پیدا نشد" + $" {_currentUserService.UserName}");
        var userId = _currentUserService.UserId.ToInt();
        var link = await _paymentService.CreatePaymentLink(amount, userId, $"{user.FirstName} {user.LastName}", user.PhoneNumber);
        return new IncreaseInventoryResponseDto
        {
            Increased = false,
            NeedToPayment = true,
            PaymentUrl = link
        };
    }
}