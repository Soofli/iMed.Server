namespace iMed.Server.Controllers.V1;

[Route("[controller]")]
[AllowAnonymous]
[ApiController]
public class HealthController : ControllerBase
{
    private readonly ApplicationContext _context;
    public HealthController(ApplicationContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetHealth()
    {
        var version = typeof(Program).Assembly.GetName().Version.ToString();
        var check = new HealthCheck
        {
            Health = true,
            Version = version
        };
        var process = Process.GetCurrentProcess();
        check.TotalMemory = process.PrivateMemorySize64.ToString();

        return Ok(check);
    }
}