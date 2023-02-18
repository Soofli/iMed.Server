namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class AccountController : BaseController
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut("User")]
    public async Task<IActionResult> EditUser([FromBody] UserSDto userDto)
        => Ok(await _accountService.EditUserAsync(userDto));

    [HttpPost("User/{userId}/Confirm")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> ConfirmUser(int userId)
        => Ok(await _accountService.ConfirmUserAsync(userId));


    [HttpPut("Admin")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> EditAdmin([FromBody] AdminSDto adminDto)
        => Ok(await _accountService.EditAdminAsync(adminDto));
}