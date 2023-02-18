namespace iMed.Core.Services.Contracts;

public interface IAccountService : IScopedDependency
{
    Task<AccessToken<Admin>> SignUpAdminAsync(SignUpRequestDto signUpDto);
    Task<AccessToken<User>> SignUpUserAsync(SignUpRequestDto signUpDto);
    Task<AccessToken<Admin>> LoginAdminAsync(string userName, string password);
    Task<AccessToken<User>> LoginUserAsync(string userName, string password);
    Task<bool> CheckMembershipAsync(string phoneNumber);
    Task<bool> ForgetPasswordAsync(string phoneNumber);
    Task<bool> EditUserAsync(UserSDto userDto);
    Task<bool> EditAdminAsync(AdminSDto adminDto);
    Task AddIdentityImageAsync(ResponseFile responseFile);
    Task<bool> ConfirmUserAsync(int userId);
}