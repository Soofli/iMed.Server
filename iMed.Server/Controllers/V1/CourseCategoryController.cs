using iMed.Domain.Models;

namespace iMed.Server.Controllers.V1;

public class CourseCategoryController : CrudController<CourseCategory,CourseCategorySDto,CourseCategoryLDto>
{
    public CourseCategoryController(IRepositoryWrapper repositoryWrapper) : base(repositoryWrapper)
    {
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> PostOrginal([FromBody] CourseCategory ent, CancellationToken cancellationToken)
    {
        return base.PostOrginal(ent, cancellationToken);
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> Put([FromBody] CourseCategory ent, CancellationToken cancellationToken)
    {
        return base.Put(ent, cancellationToken);
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var coursesCount = await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .Where(c => c.CourseCategoryId == id).CountAsync(cancellationToken);
        if (coursesCount > 0)
            throw new BaseApiException(ApiResultStatusCode.BadRequest, "دسته بندی مورد نظر دارای دوره فعال می باشد ، برای حذف دسته بندی باید نخست دوره های مورد نظر را به دسته بندی دیگری منتقل کرده یا حذف کنید");
        return await base.Delete(id, cancellationToken);
    }
}