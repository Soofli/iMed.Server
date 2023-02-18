namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[AllowAnonymous]
public class AuthorizeController : BaseController
{
    private readonly IAccountService _accountService;

    public AuthorizeController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPost("[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public async Task<IActionResult> SignUpAdmin([FromBody] SignUpRequestDto signUpDto) => Ok(await _accountService.SignUpAdminAsync(signUpDto));

    [HttpPost("[action]")]
    public async Task<IActionResult> SignUpUser([FromBody] SignUpRequestDto signUpDto) => Ok(await _accountService.SignUpUserAsync(signUpDto));

    [HttpPost("[action]")]
    public async Task<IActionResult> LoginAdmin([FromBody] LoginRequestDto loginRequestDto) => Ok(await _accountService.LoginAdminAsync(loginRequestDto.UserName, loginRequestDto.Password));

    [HttpPost("[action]")]
    public async Task<IActionResult> LoginUser([FromBody] LoginRequestDto loginRequestDto) => Ok(await _accountService.LoginUserAsync(loginRequestDto.UserName, loginRequestDto.Password));

    [HttpPost("[action]")]
    public async Task<IActionResult> VerifyPhoneNumber([FromQuery]string phoneNumber) => Ok(await _accountService.CheckMembershipAsync(phoneNumber));
    
    [HttpPost("[action]")]
    public async Task<IActionResult> ForgetPassword([FromQuery] string phoneNumber) => Ok(await _accountService.ForgetPasswordAsync(phoneNumber));
}