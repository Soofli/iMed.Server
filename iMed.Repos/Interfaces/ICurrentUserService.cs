namespace iMed.Repos.Interfaces;

public interface ICurrentUserService : IScopedDependency
{
    string UserId { get; }
    string UserName { get; }
}