namespace iMed.Repos.Repositories.Contracts;

public interface IRateRepository : IWriteRepository<Rate>, IReadRepository<Rate>, IScopedDependency
{
    public Task<List<CourseRate>> GetCourseRatesAsync(int courseId, int page = 1, CancellationToken cancellationToken = default);
}