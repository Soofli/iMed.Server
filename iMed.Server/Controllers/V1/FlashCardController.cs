namespace iMed.Server.Controllers.V1;

public class FlashCardController : CrudController<FlashCardSDto, FlashCard>
{
    private readonly IFlashCardRepository _flashCardRepository;
    private readonly IFlashCardService _flashCardService;

    public FlashCardController(IRepositoryWrapper repositoryWrapper, IFlashCardRepository flashCardRepository,IFlashCardService flashCardService) : base(repositoryWrapper)
    {
        _flashCardRepository = flashCardRepository;
        _flashCardService = flashCardService;
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override async Task<IActionResult> Put(FlashCard ent, CancellationToken cancellationToken)
    {
        await _flashCardRepository.UpdateAsync(ent, cancellationToken);
        return Ok();
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public override async Task<IActionResult> PostOrginal(FlashCard ent, CancellationToken cancellationToken)
    {

        if (ent.Question.IsNullOrEmpty())
            throw new AppException("متن سوال خالی است");
        if (ent.FlashCardAnswers.Count < 1)
            throw new AppException("حداقل باید یک جواب ارسال شود");
        if(ent.FlashCardAnswers.Where(fca=>fca.IsTrue).Count()<1)
            throw new AppException("حداقل باید یک جواب صحیح ارسال شود");

        await _flashCardService.AddFlashCardAsync(ent,cancellationToken);
        return Ok();
    }

    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async override Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        await _flashCardService.RemoveFlashCardAsync(id, cancellationToken);
        return Ok();
    }
}