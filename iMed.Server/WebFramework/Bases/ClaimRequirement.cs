using iMed.Domain.Models;
using Microsoft.Extensions.Primitives;

namespace iMed.Server.WebFramework.Bases;
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class ClaimRequirement : AuthorizeAttribute, IAuthorizationFilter
{
    private readonly string _claimsRequire;
    private readonly string _claimType;
    public ClaimRequirement(string claimType,string claimsRequire)
    {
        _claimsRequire = claimsRequire;
        _claimType = claimType;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var user = context.HttpContext.User;
        var permissions = user.Claims?.Where(c => c.Type == _claimType)?.ToList();
        if (permissions == null)
        {
            context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
        }
        else
        {
            bool isAccepted = false;
            foreach (var claim in _claimsRequire)
            {
                if (permissions.FirstOrDefault(p => p.Value == _claimsRequire) != null)
                    isAccepted = true;

            }
            if (!isAccepted)
                context.Result = new StatusCodeResult((int)HttpStatusCode.Forbidden);
        }
    }
}
