namespace iMed.Server.Controllers.V1;

public class RateController : CrudController<Rate>
{
    private readonly IRateRepository _rateRepository;
    private readonly IRateService _rateService;

    public RateController(IRepositoryWrapper repositoryWrapper, IRateRepository rateRepository, IRateService rateService) : base(repositoryWrapper)
    {
        _rateRepository = rateRepository;
        _rateService = rateService;
    }
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> GetAllAsync()
    {
        return base.GetAllAsync();
    }

    [HttpGet("CourseRate")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetCourseRate([FromQuery] int page, CancellationToken cancellationToken)
    {
        var rates = await _repositoryWrapper.SetRepository<CourseRate>()
            .TableNoTracking
            .OrderByDescending(r => r.CreatedAt)
            .Skip(page * 30)
            .Take(30)
            .Select(CourseRateMapper.ProjectToSDto)
            .ToListAsync();
        return Ok(rates);
    }
    [HttpGet("FlashCardCategoryRate")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetFlashCardCategoryRate([FromQuery] int page, CancellationToken cancellationToken)
    {
        var rates = await _repositoryWrapper.SetRepository<FlashCardCategoryRate>()
            .TableNoTracking
            .OrderByDescending(r => r.CreatedAt)
            .Skip(page * 30)
            .Take(30)
            .ToListAsync();
        foreach (var rate in rates)
        {
            rate.FlashCardCategory = await _repositoryWrapper.SetRepository<FlashCardCategory>()
                .TableNoTracking
                .FirstOrDefaultAsync(f => f.FlashCardCategoryId == rate.FlashCardCategoryId);
        }
        return Ok(rates.Select(r=>r.AdaptToSDto()).ToList());
    }

    [HttpPost("CourseRate")]
    public async Task<IActionResult> PostCourseRate(CourseRate courseRate, CancellationToken cancellationToken)
    {
        await _repositoryWrapper.SetRepository<CourseRate>()
            .AddAsync(courseRate, cancellationToken);
        return Ok();
    }


    [HttpPost("FlashCardCategoryRate")]
    public async Task<IActionResult> PostFlashCardCategoryRate(FlashCardCategoryRate flashCardCategoryRate, CancellationToken cancellationToken)
    {
        await _repositoryWrapper
            .SetRepository<FlashCardCategoryRate>()
            .AddAsync(flashCardCategoryRate, cancellationToken);
        return Ok();
    }

    [HttpPost("{rateId}/[action]")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> ConfirmRate(int rateId, CancellationToken cancellationToken)
    {
        await _rateService.ConfirmRateAsync(rateId, cancellationToken);
        return Ok();
    }

    [HttpGet("CourseRate/{courseId}")]
    public async Task<IActionResult> GetCourseRates(int courseId, [FromQuery] int page, CancellationToken cancellationToken)
        => Ok(await _rateRepository.GetCourseRatesAsync(courseId, page, cancellationToken));

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
        => Ok(await _rateService.DeleteRateAsync(id, cancellationToken));
}