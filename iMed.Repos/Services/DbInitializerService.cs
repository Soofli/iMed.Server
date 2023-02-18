using iMed.Domain.Models;

namespace iMed.Repos.Services;


public class DbInitializerService : IDbInitializerService
{

    private readonly ApplicationContext _context;
    private readonly RoleManager<BaseRole> _roleManager;
    private readonly UserManager<Admin> _userManager;
    private readonly IOptionsSnapshot<SiteSettings> _adminUserSeedOptions;
    private readonly ILogger<DbInitializerService> _logger;

    public DbInitializerService(
        ApplicationContext context,
        RoleManager<BaseRole> roleManager,
        UserManager<Admin> userManager,
        IOptionsSnapshot<SiteSettings> adminUserSeedOptions,
        ILogger<DbInitializerService> logger)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
        _adminUserSeedOptions = adminUserSeedOptions;
        _logger = logger;
    }
    public void Initialize()
    {
        try
        {
            _context.Database.Migrate();
            _logger.LogInformation("Migration SUCCESS !!!!");
        }
        catch (Exception e)
        {
            _logger.LogError(e, e.Message);
        }
    }

    public async Task SeedDate(bool force = false)
    {
        try
        {

            await SeedRoles();

            var seedAdmin = _adminUserSeedOptions.Value.UserSetting;

            var user = await _userManager.FindByNameAsync(seedAdmin.Username);
            if (user == null)
            {
                var adminUser = new Admin
                {
                    UserName = seedAdmin.Username,
                    Email = seedAdmin.Email,
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                    FirstName = seedAdmin.FirstName,
                    LastName = seedAdmin.LastName,
                    Gender = Gender.Mail,
                    PhoneNumberConfirmed = true,
                    PhoneNumber = seedAdmin.Phone,
                    BirthDate = DateTime.Now.AddYears(-23)
                };
                var adminUserResult = await _userManager.CreateAsync(adminUser, seedAdmin.Password);
                if (adminUserResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(adminUser, seedAdmin.RoleName);
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task SeedRoles()
    {
        var seedAdmin = _adminUserSeedOptions.Value.UserSetting;
        var managerRole = await _roleManager.FindByNameAsync(seedAdmin.RoleName);
        if (managerRole == null)
        {
            managerRole = new BaseRole()
            {
                Name = seedAdmin.RoleName,
                Description = "root admin role"
            };
            await _roleManager.CreateAsync(managerRole);
        }

        var userRole = await _roleManager.FindByNameAsync(RoleNames.UserRole);
        if (userRole == null)
        {
            userRole = new BaseRole()
            {
                Name = RoleNames.UserRole,
                Description = "User of imed"
            };
            await _roleManager.CreateAsync(userRole);
        }

        var adminRole = await _roleManager.FindByNameAsync(RoleNames.AdminRole);
        if (adminRole == null)
        {
            adminRole = new BaseRole()
            {
                Name = RoleNames.AdminRole,
                Description = "Admin of imed"
            };
            await _roleManager.CreateAsync(adminRole);
        }

    }
}