using iMed.Domain.Dtos.LargDtos;
using System.Threading;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Mappers;

namespace iMed.Repos.Repositories;

public class FlashCardCategoryRepository : BaseRepository<FlashCardCategory>, IFlashCardCategoryRepository
{
    public FlashCardCategoryRepository(ApplicationContext dbContext, ICurrentUserService currentUserService) : base(dbContext, currentUserService)
    {
    }

    private IBaseRepository<T> SetRepository<T>() where T : ApiEntity => new BaseRepository<T>(DbContext, _currentUserService);
    public override async Task UpdateAsync(FlashCardCategory entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        var dbImage = await DbContext.Set<FlashCardCategoryImage>()
            .AsNoTracking()
            .FirstOrDefaultAsync(i => i.FlashCardCategoryId == entity.FlashCardCategoryId, cancellationToken);
        if (dbImage != null)
        {
            var image = entity.Image;
            if (image != null)
            {
                dbImage.FileLocation = image.FileLocation;
                dbImage.FileName = image.FileName;
                dbImage.Name = image.FileName;
                dbImage.ModifiedAt = DateTime.Now;
                dbImage.ModifiedBy = _currentUserService.UserName;
                entity.Image = dbImage;
            }
            else
            {
                DbContext.Entry(dbImage).State = EntityState.Deleted;
                await DbContext.SaveChangesAsync(cancellationToken);
            }
        }
        var tags = await DbContext.Set<FlashCardTag>()
            .AsNoTracking()
            .Where(a => a.FlashCardCategoryId == entity.FlashCardCategoryId)
            .ToListAsync(cancellationToken);
        if (tags.Count > 0)
        {
            if (entity.FlashCardTags is { Count: > 0 })
            {
                foreach (var tag in tags)
                {
                    if (entity.FlashCardTags.Any(h => h.Name == tag.Name))
                        continue;

                    tag.IsRemoved = true;
                    tag.RemovedBy = _currentUserService.UserName;
                    tag.RemovedAt = DateTime.Now;
                    entity.FlashCardTags.Add(tag);
                }
            }
            else
            {
                entity.FlashCardTags = new List<FlashCardTag>();
                foreach (var tag in tags)
                {
                    tag.IsRemoved = true;
                    tag.RemovedBy = _currentUserService.UserName;
                    tag.RemovedAt = DateTime.Now;
                    entity.FlashCardTags.Add(tag);
                }
            }
        }
        var dbEntity = await TableNoTracking.FirstOrDefaultAsync(fc=>fc.FlashCardCategoryId == entity.FlashCardCategoryId);
        entity.RateAvg = dbEntity?.RateAvg ?? 0;
        await base.UpdateAsync(entity, cancellationToken, saveNow);
    }
    public override async Task DeleteAsync(FlashCardCategory entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        await base.DeleteAsync(entity, cancellationToken, saveNow);
        var rates = await SetRepository<FlashCardCategoryRate>()
            .TableNoTracking
            .Where(cr => cr.FlashCardCategoryId == entity.FlashCardCategoryId)
            .ToListAsync();
        foreach (var rate in rates)
            await SetRepository<FlashCardCategoryRate>().DeleteAsync(rate, cancellationToken);
    }
    public async Task<FlashCardCategoryLDto> GetLDtoAsync(int id)
    {
        var category = await TableNoTracking
            .Where(c => c.FlashCardCategoryId == id)
            .Select(FlashCardCategoryMapper.ProjectToLDto)
            .FirstOrDefaultAsync();
        category.FlashCards = new List<FlashCardSDto>();
        foreach (var tag in category.FlashCardTags)
        {
            category.FlashCards.AddRange(await SetRepository<FlashCard>().TableNoTracking.Where(f => f.FlashCardTagId == tag.FlashCardTagId)
                .Select(FlashCardMapper.ProjectToSDto)
                .ToListAsync());
            category.FlashCards.ForEach(f => f.ImageFileName = category.ImageFileName);
        }

        return category;
    }

    public async Task<bool> ChangeActiveStatusAsync(int id, bool isActive)
    {
        var category = await TableNoTracking.FirstOrDefaultAsync(c=>c.FlashCardCategoryId==id);
        category.IsActive = isActive;
        await base.UpdateAsync(category, default);
        return true;
    }
}