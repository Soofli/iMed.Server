namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PageController : BaseController
{
    private readonly IPageService _pageService;

    public PageController(IPageService pageService)
    {
        _pageService = pageService;
    }


    [HttpGet("Admin/DashboardPage")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetDashboardPage(CancellationToken cancellationToken)
        => Ok(await _pageService.GetAdminDashboardPageAsync(cancellationToken));

    [HttpGet("Admin/FlashCardCategory/{id}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetFlashCardCategoryEditPage(int id, CancellationToken cancellationToken)
        => Ok(await _pageService.GetFlashCardCategoryAdminPageAsync(id, cancellationToken));

    [HttpGet("Admin/PurchasePage")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetPurchasePage(int id, CancellationToken cancellationToken)
        => Ok(await _pageService.GetFlashCardCategoryAdminPageAsync(id, cancellationToken));


    [HttpGet("App/MainPage")]
    public async Task<IActionResult> AppMainPage()
        => Ok(await _pageService.GetMainPageAsync());

    [HttpGet("App/SearchPage")]
    public async Task<IActionResult> AppSearchPage([FromQuery]string search)
        => Ok(await _pageService.GetSearchPageAsync(search));


    [HttpGet("App/ProfilePage")]
    public async Task<IActionResult> AppProfilePage()
        => Ok(await _pageService.GetProfilePageAsync());


    [HttpGet("App/PurchasesPage")]
    public async Task<IActionResult> PurchasesPage()
        => Ok(await _pageService.GetPurchasePageAsync());


    [HttpGet("App/CoursePage/{courseId}")]
    public async Task<IActionResult> AppCoursePage(int courseId)
        => Ok(await _pageService.GetCoursePageAsync(courseId));


    [HttpGet("App/FlashCardCategoryPage/{flashCardCategoryId}")]
    public async Task<IActionResult> AppFlashCardCategoryPage(int flashCardCategoryId , CancellationToken cancellationToken)
        => Ok(await _pageService.GetFlashCardCategoryAppPageAsync(flashCardCategoryId, cancellationToken));


    [HttpGet("App/LeitnerBoxPage")]
    public async Task<IActionResult> AppLeitnerBoxPagePage( CancellationToken cancellationToken)
        => Ok(await _pageService.GetLeitnerBoxAppPageAsync( cancellationToken));

}