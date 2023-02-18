namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class WalletController : BaseController
{
    private readonly IWalletService _walletService;

    public WalletController(IWalletService walletService)
    {
        _walletService = walletService;
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> IncreaseInventory([FromQuery] int amount) => Ok(await _walletService.IncreaseInventoryAsync(amount));
}