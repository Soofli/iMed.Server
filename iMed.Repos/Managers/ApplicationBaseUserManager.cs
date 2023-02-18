namespace iMed.Repos.Managers;

public class ApplicationBaseUserManager<TUser, TRole>
    where TUser : BaseUser
    where TRole : BaseRole

{
    private readonly ApplicationContext _context;
    private readonly RoleManager<TRole> _roleManager;
    private readonly UserManager<TUser> _userManager;

    public ApplicationBaseUserManager(ApplicationContext context,
        UserManager<TUser> userManager,
        RoleManager<TRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }
}