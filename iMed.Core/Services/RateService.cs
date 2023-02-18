using System.Threading;

namespace iMed.Core.Services;
internal enum RateChangeType
{
    FlashCardCategory,
    Course
}
public class RateService : IRateService
{
    private readonly IRepositoryWrapper _repositoryWrapper;

    public RateService(IRepositoryWrapper repositoryWrapper)
    {
        _repositoryWrapper = repositoryWrapper;
    }
    public async Task ConfirmRateAsync(int rateId, CancellationToken cancellationToken)
    {
        var rate = await _repositoryWrapper.SetRepository<Rate>().TableNoTracking
            .FirstOrDefaultAsync(r => r.RateId == rateId, cancellationToken);
        if (rate == null)
            throw new AppException("نظر مورد نظر پیدا نشد");
        rate.IsConfirmed = true;

        var courseRate = await _repositoryWrapper.SetRepository<CourseRate>()
                .Entities.AsNoTracking()
                .FirstOrDefaultAsync(r => r.RateId == rateId, cancellationToken);

        var flashCardCategoryRate = await _repositoryWrapper.SetRepository<FlashCardCategoryRate>()
                .Entities.AsNoTracking()
                .FirstOrDefaultAsync(r => r.RateId == rateId, cancellationToken);

        await _repositoryWrapper.SetRepository<Rate>().UpdateAsync(rate, cancellationToken);
        if (courseRate != null)
            await ChangeEntityScoreAvg(RateChangeType.Course, courseRate.CourseId, cancellationToken);
        else if (flashCardCategoryRate != null)
            await ChangeEntityScoreAvg(RateChangeType.FlashCardCategory, flashCardCategoryRate.FlashCardCategoryId, cancellationToken);
    }
    public async Task<bool> DeleteRateAsync(int rateId, CancellationToken cancellationToken)
    {
        var rate = await _repositoryWrapper.SetRepository<Rate>().TableNoTracking
            .FirstOrDefaultAsync(r => r.RateId == rateId, cancellationToken);
        if (rate == null)
            throw new AppException("نظر مورد نظر پیدا نشد");

        var courseRate = await _repositoryWrapper.SetRepository<CourseRate>()
                .Entities.AsNoTracking()
                .FirstOrDefaultAsync(r => r.RateId == rateId, cancellationToken);

        var flashCardCategoryRate = await _repositoryWrapper.SetRepository<FlashCardCategoryRate>()
                .Entities.AsNoTracking()
                .FirstOrDefaultAsync(r => r.RateId == rateId, cancellationToken);


        await _repositoryWrapper.SetRepository<Rate>().DeleteAsync(rate, cancellationToken);

        if (courseRate != null)
            await ChangeEntityScoreAvg(RateChangeType.Course, courseRate.CourseId, cancellationToken);
        else if (flashCardCategoryRate != null)
            await ChangeEntityScoreAvg(RateChangeType.FlashCardCategory, flashCardCategoryRate.FlashCardCategoryId, cancellationToken);

        return true;
    }
    private async Task ChangeEntityScoreAvg(RateChangeType rateChangeType, int dateId, CancellationToken cancellationToken)
    {
        if (rateChangeType == RateChangeType.Course)
        {
            var course = await _repositoryWrapper.SetRepository<Course>()
                .TableNoTracking.FirstOrDefaultAsync(c => c.CourseId == dateId, cancellationToken);
            if (course == null)
                return;
            var rateCount = await _repositoryWrapper.SetRepository<CourseRate>()
                .TableNoTracking
                .CountAsync(r => r.IsConfirmed && r.CourseId == dateId, cancellationToken);
            double rateAvg = await _repositoryWrapper.SetRepository<CourseRate>()
                .TableNoTracking
                .Where(r => r.IsConfirmed && r.CourseId == dateId)
                .SumAsync(r => r.Score, cancellationToken) / (double)rateCount;
            course.RateAvg = rateAvg;
            await _repositoryWrapper.SetRepository<Course>().UpdateAsync(course, cancellationToken);
        }
        else
        {
            var flashCardCategory = await _repositoryWrapper.SetRepository<FlashCardCategory>()
                .TableNoTracking
                .FirstOrDefaultAsync(r => r.FlashCardCategoryId == dateId, cancellationToken);
            if (flashCardCategory == null)
                return;
            var rateCount = await _repositoryWrapper.SetRepository<FlashCardCategoryRate>()
                .TableNoTracking
                .CountAsync(r => r.FlashCardCategoryId == dateId && r.IsConfirmed, cancellationToken);
            double rateAvg = await _repositoryWrapper.SetRepository<FlashCardCategoryRate>()
                .TableNoTracking
                .Where(r => r.FlashCardCategoryId == dateId && r.IsConfirmed)
                .SumAsync(r => r.Score, cancellationToken) / (double)rateCount;
            flashCardCategory.RateAvg = rateAvg;
            await _repositoryWrapper.SetRepository<FlashCardCategory>().UpdateAsync(flashCardCategory, cancellationToken);

        }
    }
}