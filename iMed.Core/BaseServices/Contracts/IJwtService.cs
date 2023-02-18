namespace iMed.Core.BaseServices.Contracts;

public interface IJwtService : IScopedDependency
{
    Task<AccessToken<TUser>> Generate<TUser>(TUser user) where TUser : BaseUser;

}