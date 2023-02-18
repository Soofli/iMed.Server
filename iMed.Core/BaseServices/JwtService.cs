using iMed.Common.Models.Exception;
using iMed.Domain.Models;

namespace iMed.Core.BaseServices;


public class JwtService : IJwtService
{
    private readonly SignInManager<User> _signInManager;
    private readonly SignInManager<Admin> _adminSignInManager;
    private readonly SiteSettings _siteSettings;

    public JwtService(
        IOptionsSnapshot<SiteSettings> siteSettings,
        SignInManager<User> userSignInManager,
        SignInManager<Admin> adminSignInManager)
    {
        _signInManager = userSignInManager;
        _adminSignInManager = adminSignInManager;
        _siteSettings = siteSettings.Value;
    }
    public async Task<AccessToken<TUser>> Generate<TUser>(TUser user) where TUser : BaseUser
    {

        var secretKey = Encoding.UTF8.GetBytes(_siteSettings.JwtSettings.SecretKey);
        var tokenId = iMed.Common.Extensions.StringExtensions.GetId(8);
        var signingCredintial = new SigningCredentials(new SymmetricSecurityKey(secretKey), SecurityAlgorithms.HmacSha512Signature);
        var claims = await GetClaims(user, tokenId);
        var desctiptor = new SecurityTokenDescriptor
        {
            Issuer = _siteSettings.JwtSettings.Issuer,
            Audience = _siteSettings.JwtSettings.Audience,
            IssuedAt = DateTime.Now,
            NotBefore = DateTime.Now,
            Expires = DateTime.Now.AddDays(_siteSettings.JwtSettings.ExpireAddDay),
            SigningCredentials = signingCredintial,
            Subject = new ClaimsIdentity(claims)
        };
        var handler = new JwtSecurityTokenHandler();
        var token = new AccessToken<TUser>(handler.CreateJwtSecurityToken(desctiptor));
        token.User = user;
        return token;
    }
    private async Task<IEnumerable<Claim>> GetClaims<TUser>(TUser baseUser, string jwtId) where TUser : BaseUser
    {
        if (baseUser is Admin admin)
        {
            var claims = (await _adminSignInManager.ClaimsFactory.CreateAsync(admin)).Claims.ToList();
            claims.Add(new Claim("JwtID", jwtId));
            claims.Add(new Claim(ClaimTypes.Gender, admin.Gender == 0 ? "Female" : "Mail"));
            claims.Add(new Claim(CustomClaims.IsAdmin, "True"));
            return claims;
        }
        else if (baseUser is User user)
        {

            var claims = (await _signInManager.ClaimsFactory.CreateAsync(user)).Claims.ToList();
            claims.Add(new Claim("JwtID", jwtId));
            claims.Add(new Claim(ClaimTypes.Gender, user.Gender == 0 ? "Female" : "Mail"));
            return claims;
        }
        else
            throw new BaseApiException(ApiResultStatusCode.BadRequest,"This user type jwt not implemented !!");

    }
}