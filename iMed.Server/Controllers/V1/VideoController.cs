namespace iMed.Server.Controllers.V1;

[Route("api/v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class VideoController : ControllerBase
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICurrentUserService _currentUserService;
    public VideoController(IRepositoryWrapper repositoryWrapper,ICurrentUserService currentUserService)
    {
        _repositoryWrapper = repositoryWrapper;
        _currentUserService = currentUserService;
    }
    [HttpGet, Route("Validate")]
    public async Task<IActionResult> GetVideo(CancellationToken cancellationToken)
    {
        var name = HttpContext.Request.Headers["X-Original-URI"].ToString().Split("?access_token=").First().Split('/').Last();
        var video = await _repositoryWrapper.SetRepository<Video>()
            .TableNoTracking
            .FirstOrDefaultAsync(v => v.FileName == name, cancellationToken);
        if (video.IsFree)
            return Ok();
        if (video == null)
            throw new AppException("ویدیو پیدا نشد");
        var purchase = await _repositoryWrapper.SetRepository<CoursePurchase>().TableNoTracking
            .FirstOrDefaultAsync(v => v.UserId == _currentUserService.UserId.ToInt() && v.CourseId == video.CourseId, cancellationToken);
        if (purchase == null)
            throw new AppException("شما این ویدیو را خریداری نکرده اید");
        return Ok();
    }
}