namespace iMed.Repos.Repositories;

public class RateRepository : BaseRepository<Rate> , IRateRepository
{
    public RateRepository(ApplicationContext dbContext, ICurrentUserService currentUserService) : base(dbContext, currentUserService)
    {
    }
    private IBaseRepository<T> SetRepository<T>() where T : ApiEntity => new BaseRepository<T>(DbContext, _currentUserService);

    public async Task<List<CourseRate>> GetCourseRatesAsync(int courseId, int page = 1 , CancellationToken cancellationToken = default)
    {
        if (page < 0)
            throw new BaseApiException(ApiResultStatusCode.BadRequest, "شماره صفحه نمی تواند کمتر از 0 باشد");
        var rates = await SetRepository<CourseRate>()
            .TableNoTracking
            .Where(cr => cr.CourseId == courseId && cr.IsConfirmed)
            .Skip(10 * (page - 1))
            .Take(10)
            .OrderByDescending(cr => cr.CreatedAt)
            .ToListAsync(cancellationToken);
        return rates;
    }
}