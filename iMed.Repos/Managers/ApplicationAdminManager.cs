namespace iMed.Repos.Managers;

public class ApplicationAdminManager : UserManager<Admin>, IScopedDependency
{
    public ApplicationAdminManager(IUserStore<Admin> store, IOptions<IdentityOptions> optionsAccessor,
        IPasswordHasher<Admin> passwordHasher, IEnumerable<IUserValidator<Admin>> userValidators,
        IEnumerable<IPasswordValidator<Admin>> passwordValidators, ILookupNormalizer keyNormalizer,
        IdentityErrorDescriber errors, IServiceProvider services, ILogger<UserManager<Admin>> logger) : base(store,
        optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
    }
}