namespace iMed.Core.Services;

public class FlashCardService : IFlashCardService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly IFlashCardRepository _flashCardRepository;

    public FlashCardService(IRepositoryWrapper repositoryWrapper,IFlashCardRepository flashCardRepository)
    {
        _repositoryWrapper = repositoryWrapper;
        _flashCardRepository = flashCardRepository;
    }
    public async Task AddFlashCardAsync(FlashCard ent, CancellationToken cancellationToken)
    {
        await _flashCardRepository.AddAsync(ent, cancellationToken);

        var tag = await _repositoryWrapper.SetRepository<FlashCardTag>().TableNoTracking
            .FirstOrDefaultAsync(t => t.FlashCardTagId == ent.FlashCardTagId);

        var purchases = await _repositoryWrapper.SetRepository<FlashCardCategoryPurchase>().TableNoTracking
            .Where(fcc => fcc.FlashCardCategoryId == tag.FlashCardCategoryId)
            .ToListAsync();
        foreach (var purchase in purchases)
        {

            var userFlashCard = new UserFlashCardStatus
            {
                UserId = purchase.UserId,
                FlashCardId = ent.FlashCardId,
                FlashCardStatus = FlashCardStatus.Step0,
                NextReviewAt = DateTime.Now,

            };
            await _repositoryWrapper.SetRepository<UserFlashCardStatus>().AddAsync(userFlashCard, cancellationToken);
        }
    }

    public async Task RemoveFlashCardAsync(int id, CancellationToken cancellationToken)
    {
        var ent = await _repositoryWrapper.SetRepository<FlashCard>().TableNoTracking.FirstOrDefaultAsync(fc => fc.FlashCardId == id);
        await _flashCardRepository.DeleteAsync(ent,cancellationToken);
        var userFlashCards = await _repositoryWrapper.SetRepository<UserFlashCardStatus>().TableNoTracking
            .Where(ufc => ufc.FlashCardId == id)
            .ToListAsync();
        foreach (var userFlashCard in userFlashCards)
        {
            await _repositoryWrapper.SetRepository<UserFlashCardStatus>().DeleteAsync(userFlashCard, cancellationToken);
        }
    }
}