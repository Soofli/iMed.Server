namespace iMed.Repos.Repositories;

public class CourseRepository : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(ApplicationContext dbContext, ICurrentUserService currentUserService) : base(dbContext, currentUserService)
    {
    }

    private IBaseRepository<T> SetRepository<T>() where T : ApiEntity => new BaseRepository<T>(DbContext, _currentUserService);

    public override async Task UpdateAsync(Course entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        var image = entity.Image;
        if (image != null)
        {
            IBaseRepository<CourseImage> imageRepos = SetRepository<CourseImage>();
            if (image.ImageId > 0)
            {
                var dbImage = await imageRepos.TableNoTracking.FirstOrDefaultAsync(i => i.ImageId == image.ImageId, cancellationToken);
                if (dbImage != null)
                {
                    dbImage.FileLocation = image.FileLocation;
                    dbImage.FileName = image.FileName;
                    dbImage.Name = image.FileName;
                    dbImage.ModifiedAt = DateTime.Now;
                    dbImage.ModifiedBy = _currentUserService.UserName;
                    await SetRepository<CourseImage>().UpdateAsync(dbImage, default);
                }

            }
            else
            {
                image.CourseId = entity.CourseId;
                image.CreatedAt = DateTime.Now;
                image.CreatedBy = _currentUserService.UserName;
                await SetRepository<CourseImage>().AddAsync(image, default);
            }

            entity.Image = null;
        }

        var handouts = await DbContext.Set<CourseHandout>()
            .AsNoTracking()
            .Where(m => m.CourseId == entity.CourseId)
            .ToListAsync(cancellationToken);
        var videos = await DbContext.Set<Video>()
            .AsNoTracking()
            .Where(m => m.CourseId == entity.CourseId)
            .ToListAsync(cancellationToken);
        if (handouts.Count > 0)
        {
            if (entity.Handouts is { Count: > 0 } )
                foreach (var handout in handouts)
                {
                    if (entity.Handouts.Any(h => h.HandoutId == handout.HandoutId))
                        continue;
                    handout.IsRemoved = true;
                    handout.RemovedBy = _currentUserService.UserName;
                    handout.RemovedAt = DateTime.Now;
                    entity.Handouts.Add(handout);
                }
            else
            {
                entity.Handouts = new List<CourseHandout>();
                foreach (var handout in handouts)
                {
                    handout.IsRemoved = true;
                    handout.RemovedBy = _currentUserService.UserName;
                    handout.RemovedAt = DateTime.Now;
                    entity.Handouts.Add(handout);
                }
            }
        }

        if (videos.Count > 0)
        {
            if (entity.Videos is { Count: > 0 })
                foreach (var video in videos)
                {
                    if (entity.Videos.Any(h => h.VideoId == video.VideoId))
                        continue;
                    video.IsRemoved = true;
                    video.RemovedBy = _currentUserService.UserName;
                    video.RemovedAt = DateTime.Now;
                    entity.Videos.Add(video);
                }
            else
            {
                entity.Videos = new List<Video>();
                foreach (var video in videos)
                {
                    video.IsRemoved = true;
                    video.RemovedBy = _currentUserService.UserName;
                    video.RemovedAt = DateTime.Now;
                    entity.Videos.Add(video);
                }
            }
        }

        AssertExtensions.NotNull(entity, nameof(entity));
        var entry = await TableNoTracking.FirstOrDefaultAsync(t => t.Equals(entity), cancellationToken);
        if (entry != null)
        {
            entity.CreatedBy = entry.CreatedBy;
            entity.CreatedAt = entry.CreatedAt;
            entity.RateAvg = entry.RateAvg;
        }

        entity.ModifiedAt = DateTime.Now;
        entity.ModifiedBy = _currentUserService.UserName;
        DbContext.Update(entity);
        if (saveNow)
            await DbContext.SaveChangesAsync(cancellationToken);
    }
    public override async Task DeleteAsync(Course entity, CancellationToken cancellationToken, bool saveNow = true)
    {
        await base.DeleteAsync(entity, cancellationToken, saveNow);
        var rates = await SetRepository<CourseRate>().TableNoTracking.Where(cr => cr.CourseId == entity.CourseId).ToListAsync();
        foreach (var rate in rates)
            await SetRepository<CourseRate>().DeleteAsync(rate, cancellationToken);
    }
}