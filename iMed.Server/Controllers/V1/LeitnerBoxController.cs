namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class LeitnerBoxController : BaseController
{
    private readonly ILeitnerBoxService _leitnerBoxService;

    public LeitnerBoxController(ILeitnerBoxService leitnerBoxService)
    {
        _leitnerBoxService = leitnerBoxService;
    }

    [HttpPost("User/Archive/{ufcId}")]
    public async Task<IActionResult> ArchiveFlashCard(int ufcId,CancellationToken cancellationToken)
        => Ok(await _leitnerBoxService.ArchiveFlashCardAsync(ufcId));

    [HttpGet("User")]
    public async Task<IActionResult> GetUserFlashCards(CancellationToken cancellationToken)
        => Ok(await _leitnerBoxService.GetUserFlashCardsAsync());

    [HttpPost("User/Answer/{answerId}")]
    public async Task<IActionResult> SubmitUserAnswer(int answerId,[FromQuery] double elapsedTime, CancellationToken cancellationToken)
        => Ok(await _leitnerBoxService.SubmitAnswersAsync(new SubmitAnswerRequest { AnswerId = answerId, ElapsedTime = elapsedTime }));

    [HttpPost("User/Answer")]
    public async Task<IActionResult> SubmitUserAnswers([FromBody]List<SubmitAnswerRequest> answerRequests,CancellationToken cancellationToken)
        => Ok(await _leitnerBoxService.SubmitAnswersAsync(answerRequests.ToArray()));

    [HttpPost("User/Answer/Multi")]
    public async Task<IActionResult> SubmitUserMultiAnswer([FromBody] List<SubmitAnswerRequest> answerRequests, [FromQuery] int flashCardId, CancellationToken cancellationToken)
        => Ok(await _leitnerBoxService.SubmitMultipleAnswersAsync(flashCardId, answerRequests.ToArray()));

}