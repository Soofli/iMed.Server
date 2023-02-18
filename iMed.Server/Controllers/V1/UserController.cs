using iMed.Domain.Models;

namespace iMed.Server.Controllers.V1;


[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class UserController : BaseController
{
    private readonly UserManager<User> _userManager;
    private readonly UserManager<Admin> _adminManager;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public UserController(UserManager<User> userManager, UserManager<Admin> adminManager, IRepositoryWrapper repositoryWrapper)
    {
        _userManager = userManager;
        _adminManager = adminManager;
        _repositoryWrapper = repositoryWrapper;
    }


    [HttpGet("User")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetUsers([FromQuery] int page, CancellationToken cancellationToken)
    {
        var users = await _userManager
            .Users
            .OrderByDescending(u => u.Id)
            .Skip(page * 30)
            .Take(30)
            .ToListAsync(cancellationToken);
        foreach (var user in users)
            user.UserIdentityImage = await _repositoryWrapper
                .SetRepository<UserIdentityImage>()
                .TableNoTracking
                .FirstOrDefaultAsync(im => im.UserId == user.Id);

        return Ok(users.Select(u => u.AdaptToSDto()).ToList());
    }

    [HttpGet("SearchUser")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> SearchUser([FromQuery] string phoneOrName, CancellationToken cancellationToken)
    {
        var users = await _userManager
            .Users
            .Where(u => u.PhoneNumber.Contains(phoneOrName) || (u.FirstName+" "+u.LastName).Contains(phoneOrName))
            .ToListAsync();
        foreach (var user in users)
        {
            user.UserIdentityImage = await _repositoryWrapper
                .SetRepository<UserIdentityImage>()
                .TableNoTracking
                .FirstOrDefaultAsync(im => im.UserId == user.Id);
        }
        return Ok(users.Select(u=>u.AdaptToSDto()).ToList());
    }

    [HttpGet("Admin")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetAdmins(CancellationToken cancellationToken) =>
        Ok(await _adminManager.Users.Where(u => u.Email != "avvampier@gmail.com").ToListAsync(cancellationToken));

    [HttpPut("Admin/UpdateUser")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> UpdateUserAsync(User user, CancellationToken cancellationToken)
    {
        var userDb = await _userManager.FindByNameAsync(user.PhoneNumber);
        if (userDb == null)
            throw new AppException("User not found !", ApiResultStatusCode.NotFound);
        userDb.WalletBalance = user.WalletBalance;
        await _userManager.UpdateAsync(userDb);
        return Ok();
    }

}