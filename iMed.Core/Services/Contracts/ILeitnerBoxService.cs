namespace iMed.Core.Services.Contracts;

public interface ILeitnerBoxService : IScopedDependency
{
    Task<List<SubmitFlashCardAnswerResponseDto>> SubmitAnswersAsync(params SubmitAnswerRequest[] answerRequests);
    Task<SubmitFlashCardAnswerResponseDto> SubmitMultipleAnswersAsync(int flashCardId, params SubmitAnswerRequest[] answerRequests);
    Task<List<FlashCardCategoryLDto>> GetUserFlashCardsAsync();
    FlashCardAnswerScore CheckFlashCardStatus(UserFlashCardStatus flashCardStatus, bool trueAnswer);
    Task<bool> ArchiveFlashCardAsync(int userFlashCardId);
}