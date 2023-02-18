using iMed.Domain.Enums;

namespace iMed.Repos.Repositories;

public class FlashCardRepository : BaseRepository<FlashCard>, IFlashCardRepository
{
    public FlashCardRepository(ApplicationContext dbContext, ICurrentUserService currentUserService) : base(dbContext, currentUserService)
    {
    }

    public override Task AddAsync(FlashCard entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        if (entity.FlashCardAnswers != null)
        {
            var trueCount = entity.FlashCardAnswers.Count(answer => answer.IsTrue);
            entity.FlashCardType = trueCount > 1 ? FlashCardType.MultiAnswer : FlashCardType.SingleAnswer;
        }
        return base.AddAsync(entity, cancellationToken, saveNow);
    }

    public override async Task UpdateAsync(FlashCard entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        var answers = await DbContext.Set<FlashCardAnswer>()
            .AsNoTracking()
            .Where(a => a.FlashCardId == entity.FlashCardId)
            .ToListAsync(cancellationToken);
        if (answers.Count > 0)
        {
            var trueCount = 0;
            if (entity.FlashCardAnswers is { Count: > 0 })
            {
                foreach (var answer in answers)
                {
                    if (entity.FlashCardAnswers.Any(h => h.Answer == answer.Answer))
                    {
                        if (answer.IsTrue)
                            trueCount++;
                        continue;
                    }

                    answer.IsRemoved = true;
                    answer.RemovedBy = _currentUserService.UserName;
                    answer.RemovedAt = DateTime.Now;
                    entity.FlashCardAnswers.Add(answer);
                }
            }
            else
            {
                entity.FlashCardAnswers = new List<FlashCardAnswer>();
                foreach (var answer in answers)
                {
                    answer.IsRemoved = true;
                    answer.RemovedBy = _currentUserService.UserName;
                    answer.RemovedAt = DateTime.Now;
                    entity.FlashCardAnswers.Add(answer);
                }
            }
            entity.FlashCardType = trueCount > 1 ? FlashCardType.MultiAnswer : FlashCardType.SingleAnswer;
        }
        await base.UpdateAsync(entity, cancellationToken, saveNow);
    }
}