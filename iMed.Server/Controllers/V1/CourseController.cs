namespace iMed.Server.Controllers.V1;

public class CourseController : CrudController<Course,CourseSDto,CourseLDto>
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(IRepositoryWrapper repositoryWrapper,ICourseRepository courseRepository) : base(repositoryWrapper)
    {
        _courseRepository = courseRepository;
    }

    public override async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var courses = await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .OrderByDescending(c => c.CreatedAt)
            .Select(CourseMapper.ProjectToSDto)
            .ToListAsync(cancellationToken);
        return Ok(courses);
    }

    public override async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
    {
        var course = await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .Where(c => c.CourseId == id)
            .Select(CourseMapper.ProjectToLDto)
            .FirstOrDefaultAsync(cancellationToken);
        return Ok(course);
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        return base.Delete(id, cancellationToken);
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> PostOrginal([FromBody] Course ent, CancellationToken cancellationToken)
    {
        return base.PostOrginal(ent, cancellationToken);
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override async Task<IActionResult> Put(Course ent, CancellationToken cancellationToken)
    {
        await _courseRepository.UpdateAsync(ent, cancellationToken);
        return Ok();
    }
}