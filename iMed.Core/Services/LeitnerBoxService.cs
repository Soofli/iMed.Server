using iMed.Domain.Enums;

namespace iMed.Core.Services;

public class LeitnerBoxService : ILeitnerBoxService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly UserManager<User> _userManager;

    public LeitnerBoxService(
        ICurrentUserService currentUserService,
        IRepositoryWrapper repositoryWrapper,
        UserManager<User> userManager)
    {
        _currentUserService = currentUserService;
        _repositoryWrapper = repositoryWrapper;
        _userManager = userManager;
    }
    public async Task<List<SubmitFlashCardAnswerResponseDto>> SubmitAnswersAsync(params SubmitAnswerRequest[] answerRequests)
    {
        List<SubmitFlashCardAnswerResponseDto> totalScore = new List<SubmitFlashCardAnswerResponseDto>();
        foreach (var answerRequest in answerRequests)
        {
            var answer = await _repositoryWrapper.SetRepository<FlashCardAnswer>()
                .TableNoTracking
                .FirstOrDefaultAsync(a => a.FlashCardAnswerId == answerRequest.AnswerId);
            var userFlashCardStatus = await _repositoryWrapper.SetRepository<UserFlashCardStatus>()
                .TableNoTracking
                .FirstOrDefaultAsync(uf => uf.FlashCardId == answer.FlashCardId && uf.UserId == _currentUserService.UserId.ToInt());
            await _repositoryWrapper.SetRepository<FlashCardSubmittedAnswer>().AddAsync(new FlashCardSubmittedAnswer
            {
                FlashCardAnswerId = answerRequest.AnswerId,
                ElapsedTimePerSecond = answerRequest.ElapsedTime,
                FlashCardId = answer.FlashCardId,
                UserId = _currentUserService.UserId.ToInt(),
                IsTrue = answer.IsTrue,
                Row = answer.Row
            }, default);
            var score = CheckFlashCardStatus(userFlashCardStatus, answer.IsTrue);
            await _repositoryWrapper.SetRepository<UserFlashCardStatus>().UpdateAsync(userFlashCardStatus, default);
            var user = await _userManager.FindByIdAsync(_currentUserService.UserId);
            if (user != null)
            {
                user.Score += score.Score;
                await _userManager.UpdateAsync(user);
            }
            totalScore.Add(new SubmitFlashCardAnswerResponseDto
            {
                IsTrue = answer.IsTrue,
                Score = score.Score,
            });
        }
        return totalScore;
    }

    public async Task<SubmitFlashCardAnswerResponseDto> SubmitMultipleAnswersAsync(int flashCardId, params SubmitAnswerRequest[] answerRequests)
    {
        SubmitFlashCardAnswerResponseDto rtnScore = new SubmitFlashCardAnswerResponseDto();
        bool isTrue = true;
        int trueCount = 0;
        var userFlashCardStatus = await _repositoryWrapper.SetRepository<UserFlashCardStatus>()
            .TableNoTracking
            .FirstOrDefaultAsync(uf => uf.FlashCardId == flashCardId && uf.UserId == _currentUserService.UserId.ToInt());
        if (answerRequests.Count() == 0)
            isTrue = false;
        foreach (var answerRequest in answerRequests)
        {
            var answer = await _repositoryWrapper.SetRepository<FlashCardAnswer>()
                .TableNoTracking
                .FirstOrDefaultAsync(a => a.FlashCardAnswerId == answerRequest.AnswerId);
            if (!answer.IsTrue)
                isTrue = false;
            trueCount++;
            await _repositoryWrapper.SetRepository<FlashCardSubmittedAnswer>().AddAsync(new FlashCardSubmittedAnswer
            {
                FlashCardAnswerId = answerRequest.AnswerId,
                ElapsedTimePerSecond = answerRequest.ElapsedTime,
                FlashCardId = answer.FlashCardId,
                UserId = _currentUserService.UserId.ToInt(),
                IsTrue = answer.IsTrue,
                Row = answer.Row
            }, default);
        }
        if (isTrue)
        {
            var dbTrueCount = await _repositoryWrapper.SetRepository<FlashCardAnswer>()
                .TableNoTracking
                .CountAsync(uf => uf.FlashCardId == flashCardId && uf.IsTrue);
            if (dbTrueCount != trueCount)
                isTrue = false;
        }
        var score = CheckFlashCardStatus(userFlashCardStatus, isTrue);
        await _repositoryWrapper.SetRepository<UserFlashCardStatus>().UpdateAsync(userFlashCardStatus, default);
        var user = await _userManager.FindByIdAsync(_currentUserService.UserId);
        if(user!=null)
        {
            user.Score += score.Score;
            await _userManager.UpdateAsync(user);
        }
        rtnScore.IsTrue = isTrue;
        rtnScore.Score = score.Score;
        return rtnScore;
    }

    public async Task<List<FlashCardCategoryLDto>> GetUserFlashCardsAsync()
    {
        var userReturnFlashCards = new List<FlashCardCategoryLDto>();
        var userFlashCards = await _repositoryWrapper.SetRepository<UserFlashCardStatus>()
            .TableNoTracking
            .Where(uf => uf.UserId == _currentUserService.UserId.ToInt())
            .ToListAsync();
        foreach (var userFlashCard in userFlashCards)
        {
            var flashCard = (await _repositoryWrapper.SetRepository<FlashCard>()
                .TableNoTracking
                .FirstOrDefaultAsync(f => f.FlashCardId == userFlashCard.FlashCardId)).AdaptToSDto();
            if (flashCard == null)
                continue;
            var category = userReturnFlashCards.FirstOrDefault(c => c.FlashCardCategoryId == flashCard.FlashCardCategoryId);
            flashCard.FlashCardStatus = userFlashCard.FlashCardStatus;
            flashCard.NextReviewAt = userFlashCard.NextReviewAt;
            if (category != null)
                category.FlashCards.Add(flashCard);
            else
            {
                category = (await _repositoryWrapper.SetRepository<FlashCardCategory>().TableNoTracking
                    .FirstOrDefaultAsync(c => c.FlashCardCategoryId == flashCard.FlashCardCategoryId)).AdaptToLDto();
                category.FlashCards = new List<FlashCardSDto> { flashCard };
            }


        }

        return userReturnFlashCards;
    }

    public FlashCardAnswerScore CheckFlashCardStatus(UserFlashCardStatus flashCardStatus, bool trueAnswer)
    {
        var score = new FlashCardAnswerScore { UserId = flashCardStatus.UserId };
        if (trueAnswer)
        {

            switch (flashCardStatus.FlashCardStatus)
            {
                case FlashCardStatus.Step0:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step1;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(1);
                    score.Score = 0;
                    break;
                case FlashCardStatus.Step1:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step2;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(3);
                    score.Score = 0.1;
                    break;
                case FlashCardStatus.Step2:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step3;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(7);
                    score.Score = 0.2;
                    break;
                case FlashCardStatus.Step3:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step4;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(15);
                    score.Score = 0.4;
                    break;
                case FlashCardStatus.Step4:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step5;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(30);
                    score.Score = 0.8;
                    break;
                case FlashCardStatus.Step5:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step6;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(45);
                    score.Score = 1.5;
                    break;
                case FlashCardStatus.Step6:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step7;
                    flashCardStatus.NextReviewAt = DateTime.Now.AddDays(90);
                    score.Score = 1.5;
                    break;
                case FlashCardStatus.Step7:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Done;
                    score.Score = 4.5;
                    break;
                case FlashCardStatus.Done:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Done;
                    break;
                case FlashCardStatus.Archived:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Archived;
                    break;
                default:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Step1;
                    break;
            }
        }
        else
        {

            switch (flashCardStatus.FlashCardStatus)
            {
                case FlashCardStatus.Step0:
                    score.Score = 0;
                    break;
                case FlashCardStatus.Step1:
                    score.Score = 0;
                    break;
                case FlashCardStatus.Step2:
                    score.Score = -0.1;
                    break;
                case FlashCardStatus.Step3:
                    score.Score = -0.3;
                    break;
                case FlashCardStatus.Step4:
                    score.Score = -0.7;
                    break;
                case FlashCardStatus.Step5:
                    score.Score = -1.5;
                    break;
                case FlashCardStatus.Step6:
                    score.Score = -3;
                    break;
                case FlashCardStatus.Step7:
                    score.Score = -4.5;
                    break;
                case FlashCardStatus.Done:
                    flashCardStatus.FlashCardStatus = FlashCardStatus.Done;
                    break;
            }
            flashCardStatus.FlashCardStatus = FlashCardStatus.Step1;
            flashCardStatus.NextReviewAt = DateTime.Now.AddDays(1);

        }

        return score;
    }

    public async Task<bool> ArchiveFlashCardAsync(int userFlashCardId)
    {
        var userFlashCard = await _repositoryWrapper.SetRepository<UserFlashCardStatus>()
            .TableNoTracking
            .FirstOrDefaultAsync(ufc => ufc.UserFlashCardStatusId == userFlashCardId);
        userFlashCard.FlashCardStatus = FlashCardStatus.Archived;
        await _repositoryWrapper.SetRepository<UserFlashCardStatus>().UpdateAsync(userFlashCard,default);
        return true;
    }
}