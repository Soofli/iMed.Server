using Microsoft.AspNetCore.Http.HttpResults;

namespace iMed.Server.Controllers.V1;

public class FlashCardCategoryController : CrudController<FlashCardCategory, FlashCardCategorySDto,FlashCardCategoryLDto>
{
    private readonly IFlashCardCategoryRepository _flashCardCategoryRepository;

    public FlashCardCategoryController(IRepositoryWrapper repositoryWrapper,IFlashCardCategoryRepository flashCardCategoryRepository) : base(repositoryWrapper)
    {
        _flashCardCategoryRepository = flashCardCategoryRepository;
    }
    public override Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        return base.GetAllAsync(cancellationToken);
    }
    public override async Task<IActionResult> GetAsync(int id, CancellationToken cancellationToken)
        => Ok(await _flashCardCategoryRepository.GetLDtoAsync(id));

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> PostOrginal(FlashCardCategory ent, CancellationToken cancellationToken)
    {
        return base.PostOrginal(ent, cancellationToken);
    }

    [HttpPut("ChangeActiveStatus/{flashCardCategoryId}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> ChangeActiveStatus(int flashCardCategoryId, [FromQuery] bool isActive, CancellationToken cancellationToken)
        => Ok(await _flashCardCategoryRepository.ChangeActiveStatusAsync(flashCardCategoryId, isActive));


    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override async Task<IActionResult> Put(FlashCardCategory ent, CancellationToken cancellationToken)
    {
        await _flashCardCategoryRepository.UpdateAsync(ent,cancellationToken);
        return Ok();
    }

    [HttpPut("Tag/{tagId}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> PutFlashCardTag(int tagId, [FromBody] FlashCardTag flashCardTag,CancellationToken cancellationToken)
    {
        await _repositoryWrapper.SetRepository<FlashCardTag>().UpdateAsync(flashCardTag, cancellationToken);
        return Ok();
    }


    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        return base.Delete(id, cancellationToken);
    }
}