using iMed.Core.Interfaces;
using iMed.Domain.Models;

namespace iMed.Core.Services;


public class AccountService : IAccountService
{
    private readonly UserManager<Admin> _adminManager;
    private readonly SignInManager<Admin> _adminSignInManager;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _userSignInManager;
    private readonly RoleManager<BaseRole> _roleManager;
    private readonly IJwtService _jwtService;
    private readonly ICurrentUserService _currentUserService;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ISmsService _smsService;

    public AccountService(UserManager<Admin> adminManager,
        UserManager<User> userManager,
        SignInManager<Admin> adminSignInManager,
        SignInManager<User> userSignInManager,
        RoleManager<BaseRole> roleManager,
        IJwtService jwtService,
        ICurrentUserService currentUserService,
        IRepositoryWrapper repositoryWrapper,
        ISmsService smsService)
    {
        _adminManager = adminManager;
        _adminSignInManager = adminSignInManager;
        _userManager = userManager;
        _userSignInManager = userSignInManager;
        _roleManager = roleManager;
        _jwtService = jwtService;
        _currentUserService = currentUserService;
        _repositoryWrapper = repositoryWrapper;
        _smsService = smsService;
    }
    public async Task<AccessToken<Admin>> SignUpAdminAsync(SignUpRequestDto signUpDto)
    {
        var admin = new Admin
        {
            UserName = signUpDto.UserName,
            PhoneNumber = signUpDto.Phone,
            FirstName = signUpDto.FirstName,
            LastName = signUpDto.LastName,
            Email = signUpDto.Email,
        };
        var result = await _adminManager.CreateAsync(admin, signUpDto.Password);
        if (!result.Succeeded)
            throw new AppException(string.Join('-', result.Errors.Select(e => e.Description)));

        var addRoleResult = await _adminManager.AddToRoleAsync(admin, RoleNames.AdminRole);
        if (!addRoleResult.Succeeded)
            throw new AppException(string.Join('-', addRoleResult.Errors.Select(e => e.Description)));

        var jwt = await _jwtService.Generate(admin);
        return jwt;
    }

    public async Task<AccessToken<User>> SignUpUserAsync(SignUpRequestDto signUpDto)
    {
        if (signUpDto.VerifyCode != PhoneNumberExtension.GetVerifyFromPhoneNumber(signUpDto.Phone))
            throw new BaseApiException(ApiResultStatusCode.BadRequest, "کد ارسالی اشتباه است");
        var user = new User
        {
            UserName = signUpDto.UserName,
            PhoneNumber = signUpDto.Phone,
            FirstName = signUpDto.FirstName,
            LastName = signUpDto.LastName,
            Email = signUpDto.Email,
            SignUpAt = DateTime.Now
        };
        var result = await _userManager.CreateAsync(user, signUpDto.Password);
        if (!result.Succeeded)
            throw new AppException(string.Join('-', result.Errors.Select(e => e.Description)));

        var addRoleResult = await _userManager.AddToRoleAsync(user, RoleNames.UserRole);
        if (!addRoleResult.Succeeded)
            throw new AppException(string.Join('-', addRoleResult.Errors.Select(e => e.Description)));

        var jwt = await _jwtService.Generate(user);
        return jwt;
    }

    public async Task<AccessToken<Admin>> LoginAdminAsync(string userName, string password)
    {

        var result = await _adminSignInManager.PasswordSignInAsync(userName, password, true, false);
        if (!result.Succeeded)
            throw new AppException(result.ToString());
        var admin = await _adminManager.FindByNameAsync(userName);
        var jwt = await _jwtService.Generate(admin);
        return jwt;
    }

    public async Task<AccessToken<User>> LoginUserAsync(string userName, string password)
    {
        var result = await _userSignInManager.PasswordSignInAsync(userName, password, true, false);
        if (!result.Succeeded)
            throw new AppException("رمزعبور یا شماره تلفن شما صحیح نمی باشد");
        var user = await _userManager.FindByNameAsync(userName);
        var jwt = await _jwtService.Generate(user);
        return jwt;
    }

    public async Task<bool> CheckMembershipAsync(string phoneNumber)
    {
        var user = await _userManager.FindByNameAsync(phoneNumber);
        if (user == null)
        {
            var verifyCode = PhoneNumberExtension.GetVerifyFromPhoneNumber(phoneNumber);
            await _smsService.SendVerifyCodeAsync(phoneNumber, verifyCode);
            return false;
        }
        return true;
    }

    public async Task<bool> ForgetPasswordAsync(string phoneNumber)
    {

        var user = await _userManager.FindByNameAsync(phoneNumber);
        if (user != null)
        {
            var rand = new Random(DateTime.Now.Millisecond);
            var newPass = rand.Next(1000000, 9000000).ToString();
            var rp = await _userManager.RemovePasswordAsync(user);
            if (!rp.Succeeded)
                throw new AppException(string.Join('-', rp.Errors.Select(e => e.Description)));
            var ap = await _userManager.AddPasswordAsync(user, newPass);
            if (!ap.Succeeded)
                throw new AppException(string.Join('-', ap.Errors.Select(e => e.Description)));
            await _smsService.SendForgerPasswordAsync(user.PhoneNumber, newPass);
            return true;
        }

        throw new AppException("کاربرمورد نظر پیدا نشد");
    }

    public async Task<bool> EditUserAsync(UserSDto userDto)
    {
        var user = await _userManager.FindByIdAsync(userDto.Id.ToString());
        if (user.IsConfirmed)
        {
            user.Email = userDto.Email;
            if (!string.IsNullOrEmpty(userDto.DtoPassword))
            {
                var rp = await _userManager.RemovePasswordAsync(user);
                if (!rp.Succeeded)
                    throw new AppException(string.Join('-', rp.Errors.Select(e => e.Description)));
                var ap = await _userManager.AddPasswordAsync(user, userDto.DtoPassword);
                if (!ap.Succeeded)
                    throw new AppException(string.Join('-', ap.Errors.Select(e => e.Description)));
            }
            await _userManager.UpdateAsync(user);
        }
        else
        {
            user.BirthDate = userDto.BirthDate;
            user.FirstName = userDto.FirstName;
            user.LastName = userDto.LastName;
            user.Gender = userDto.Gender;
            user.PhoneNumber = userDto.PhoneNumber;
            user.UserName = userDto.PhoneNumber;
            user.Email = userDto.Email;
            user.IdentityCode = userDto.IdentityCode;
            user.StudentCode = userDto.StudentCode;

            if (!string.IsNullOrEmpty(userDto.DtoPassword))
            {
                var rp = await _userManager.RemovePasswordAsync(user);
                if (!rp.Succeeded)
                    throw new AppException(string.Join('-', rp.Errors.Select(e => e.Description)));
                var ap = await _userManager.AddPasswordAsync(user, userDto.DtoPassword);
                if (!ap.Succeeded)
                    throw new AppException(string.Join('-', ap.Errors.Select(e => e.Description)));
            }
            await _userManager.UpdateAsync(user);
        }



        if (!await _userManager.IsInRoleAsync(user, RoleNames.UserRole))
        {
            var addRoleResult = await _userManager.AddToRoleAsync(user, RoleNames.UserRole);
            if (!addRoleResult.Succeeded)
                throw new AppException(string.Join('-', addRoleResult.Errors.Select(e => e.Description)));
        }

        return true;
    }

    public async Task<bool> EditAdminAsync(AdminSDto adminDto)
    {
        var admin = await _adminManager.FindByIdAsync(adminDto.Id.ToString());
        admin.BirthDate = adminDto.BirthDate;
        admin.FirstName = adminDto.FirstName;
        admin.LastName = adminDto.LastName;
        admin.Gender = adminDto.Gender;
        admin.PhoneNumber = adminDto.PhoneNumber;
        admin.UserName = adminDto.PhoneNumber;
        admin.Email = adminDto.Email;

        if (!string.IsNullOrEmpty(adminDto.DtoPassword))
        {
            var rp = await _adminManager.RemovePasswordAsync(admin);
            var ap = await _adminManager.AddPasswordAsync(admin, adminDto.DtoPassword);
            if (!ap.Succeeded)
                throw new AppException(ap.ToString());
        }
        await _adminManager.UpdateAsync(admin);

        if (!await _adminManager.IsInRoleAsync(admin, RoleNames.AdminRole))
        {
            var addRoleResult = await _adminManager.AddToRoleAsync(admin, RoleNames.AdminRole);
            if (!addRoleResult.Succeeded)
                throw new AppException(string.Join('-', addRoleResult.Errors.Select(e => e.Description)));
        }

        return true;
    }

    public async Task AddIdentityImageAsync(ResponseFile responseFile)
    {
        var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
        if (user == null)
            throw new BaseApiException(ApiResultStatusCode.NotFound, "کاربر مورد نظر پیدا نشد");
        var dbImage = await _repositoryWrapper.SetRepository<UserIdentityImage>().TableNoTracking
            .FirstOrDefaultAsync(i => i.UserId == user.Id);
        if (dbImage == null)
        {
            var image = new UserIdentityImage
            {
                UserId = user.Id,
                FileName = responseFile.Name,
                FileLocation = responseFile.Location,
                Name = responseFile.Name
            };
            await _repositoryWrapper.SetRepository<UserIdentityImage>().AddAsync(image, default);
        }
        else
        {
            dbImage.FileName = responseFile.Name;
            dbImage.FileLocation = responseFile.Location;
            dbImage.Name = responseFile.Name;
            await _repositoryWrapper.SetRepository<UserIdentityImage>().UpdateAsync(dbImage, default);
        }
    }

    public async Task<bool> ConfirmUserAsync(int userId)
    {
        var user = await _userManager.FindByIdAsync(userId.ToString());
        user.IsConfirmed = true;
        var res = await _userManager.UpdateAsync(user);
        if (!res.Succeeded)
            throw new AppException(string.Join(" | ", res.Errors.Select(e => e.Description)));
        return true;
    }
}