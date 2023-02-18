using FlashCardCategory = iMed.Domain.Entities.FlashCardCategory;

namespace iMed.Core.Services;
public class PageService : IPageService
{
    private readonly IRepositoryWrapper _repositoryWrapper;
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<User> _userManager;
    private readonly IFlashCardCategoryRepository _flashCardCategoryRepository;

    public PageService(IRepositoryWrapper repositoryWrapper, ICurrentUserService currentUserService, UserManager<User> userManager, IFlashCardCategoryRepository flashCardCategoryRepository)
    {
        _repositoryWrapper = repositoryWrapper;
        _currentUserService = currentUserService;
        _userManager = userManager;
        _flashCardCategoryRepository = flashCardCategoryRepository;
    }
    public async Task<MainPageDto> GetMainPageAsync()
    {
        var page = new MainPageDto();

        page.RecentCourse = new ObservableCollection<CourseSDto>(await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .OrderByDescending(c => c.CreatedAt)
            .Take(10)
            .Select(CourseMapper.ProjectToSDto)
            .ToListAsync());
        var specialCourse = await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .Where(c => c.IsSuggested)
            .OrderByDescending(c => c.CreatedAt)
            .Select(CourseMapper.ProjectToSDto)
            .ToListAsync();

        var specialFlashCard = await _repositoryWrapper.SetRepository<FlashCardCategory>()
            .TableNoTracking
            .Where(c => c.IsSuggested && c.IsActive )
            .OrderByDescending(c => c.CreatedAt)
            .Select(FlashCardCategoryMapper.ProjectToSDto)
            .ToListAsync();

        page.SpecialOffer = new ObservableCollection<SpecialOfferSDto>();
        specialCourse.ForEach(sc => page.SpecialOffer.Add(new SpecialOfferSDto
        {
            Course = sc,
            SpecialOfferType = SpecialOfferType.Course
        }));
        specialFlashCard.ForEach(sfc => page.SpecialOffer.Add(new SpecialOfferSDto
        {
            FlashCardCategory = sfc,
            SpecialOfferType = SpecialOfferType.FlashCard
        }));
        page.MineCourse = new ObservableCollection<CourseSDto>();
        var mineCoursePurchase = await _repositoryWrapper.SetRepository<CoursePurchase>()
            .TableNoTracking
            .Where(cp => cp.UserId == _currentUserService.UserId.ToInt())
            .ToListAsync();
        foreach (var coursePurchase in mineCoursePurchase)
        {
            var course = await _repositoryWrapper.SetRepository<Course>().TableNoTracking
                .Where(c => c.CourseId == coursePurchase.CourseId)
                .Select(CourseMapper.ProjectToSDto)
                .FirstOrDefaultAsync();
            if (course != null)
            {
                course.IsPurchase = true;
                page.MineCourse.Add(course);
            }
        }
        page.PopularCourse = new ObservableCollection<CourseSDto>(await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .OrderByDescending(c => c.RateAvg)
            .Take(10)
            .Select(CourseMapper.ProjectToSDto)
            .ToListAsync());


        page.RecentFlashCards = new ObservableCollection<FlashCardCategorySDto>(await _repositoryWrapper.SetRepository<FlashCardCategory>()
            .TableNoTracking
            .Where(c=> c.IsActive)
            .OrderByDescending(c => c.CreatedAt)
            .Take(20)
            .Select(FlashCardCategoryMapper.ProjectToSDto)
            .ToListAsync());

        page.MineFlashCards = new ObservableCollection<FlashCardCategorySDto>();
        var mineFlashCardPurchases = await _repositoryWrapper.SetRepository<FlashCardCategoryPurchase>()
            .TableNoTracking
            .Where(cp => cp.UserId == _currentUserService.UserId.ToInt())
            .ToListAsync();
        foreach (var flashCardCategoryPurchase in mineFlashCardPurchases)
        {
            var flashCard = await _repositoryWrapper.SetRepository<FlashCardCategory>().TableNoTracking
                .Where(c => c.FlashCardCategoryId == flashCardCategoryPurchase.FlashCardCategoryId)
                .Select(FlashCardCategoryMapper.ProjectToSDto)
                .FirstOrDefaultAsync();
            if (flashCard != null)
            {

                flashCard.IsPurchase = true;
                page.MineFlashCards.Add(flashCard);
            }
        }
        page.PopularFlashCards = new ObservableCollection<FlashCardCategorySDto>(await _repositoryWrapper.SetRepository<FlashCardCategory>()
            .TableNoTracking
            .Where(c=>c.IsActive)
            .OrderByDescending(c => c.RateAvg)
            .Take(6)
            .Select(FlashCardCategoryMapper.ProjectToSDto)
            .ToListAsync());


        return page;
    }

    public async Task<SearchPageDto> GetSearchPageAsync(string search)
    {
        var page = new SearchPageDto();
        page.Courses = new ObservableCollection<CourseSDto>(await _repositoryWrapper.SetRepository<Course>()
            .TableNoTracking
            .Where(c => c.Name.Contains(search))
            .Select(CourseMapper.ProjectToSDto)
            .ToListAsync());
        page.FlashCardCategories = new ObservableCollection<FlashCardCategorySDto>(
            await _repositoryWrapper.SetRepository<FlashCardCategory>()
            .TableNoTracking
            .Where(c => c.Name.Contains(search))
            .Select(FlashCardCategoryMapper.ProjectToSDto)
            .ToListAsync());
        return page;
    }

    public async Task<CoursePageDto> GetCoursePageAsync(int courseId)
    {
        var page = new CoursePageDto();
        page.Videos = new ObservableCollection<VideoSDto>(await _repositoryWrapper.SetRepository<Video>()
            .TableNoTracking
            .Where(v => v.CourseId == courseId)
            .Select(VideoMapper.ProjectToSDto)
            .ToListAsync());

        page.Handouts = new ObservableCollection<CourseHandoutSDto>(await _repositoryWrapper.SetRepository<CourseHandout>()
            .TableNoTracking
            .Where(v => v.CourseId == courseId)
            .Select(CourseHandoutMapper.ProjectToSDto)
            .ToListAsync());

        page.RateCount = await _repositoryWrapper.SetRepository<CourseRate>()
            .TableNoTracking
            .CountAsync(r => r.CourseId == courseId && r.IsConfirmed);

        if (page.RateCount > 0)
            page.RateAvg = (await _repositoryWrapper.SetRepository<CourseRate>()
                .TableNoTracking
                .Where(r => r.CourseId == courseId && r.IsConfirmed)
                .SumAsync(r => r.Score)) / page.RateCount;

        var purchase = await _repositoryWrapper.SetRepository<CoursePurchase>()
            .TableNoTracking
            .FirstOrDefaultAsync(cp => cp.CourseId == courseId && cp.UserId == _currentUserService.UserId.ToInt());

        page.IsPurchased = purchase == null ? page.IsPurchased = false : page.IsPurchased = true;
        page.CourseTime = $"{(int)page.Videos.Sum(v => v.VideoTime)} دقیقه";
        return page;

    }

    public async Task<FlashCardCategoryLDto> GetFlashCardCategoryAdminPageAsync(int flashCardCategoryId, CancellationToken cancellationToken)
    {
        var flashCardCategory = await _repositoryWrapper.SetRepository<FlashCardCategory>().TableNoTracking
            .FirstOrDefaultAsync(fc => fc.FlashCardCategoryId == flashCardCategoryId, cancellationToken);
        if (flashCardCategory == null)
            throw new AppException("FlashCard Category Not Found", ApiResultStatusCode.NotFound);
        flashCardCategory.FlashCardTags = await _repositoryWrapper.SetRepository<FlashCardTag>().TableNoTracking
            .Where(t => t.FlashCardCategoryId == flashCardCategoryId).ToListAsync(cancellationToken);

        var page = flashCardCategory.AdaptToLDto();
        page.FlashCards = new List<FlashCardSDto>();
        foreach (var tag in page.FlashCardTags)
        {
            page.FlashCards.AddRange(await _repositoryWrapper.SetRepository<FlashCard>().TableNoTracking
                .Where(fc => fc.FlashCardTagId == tag.FlashCardTagId)
                .Select(FlashCardMapper.ProjectToSDto)
                .ToListAsync(cancellationToken));
        }

        return page;
    }

    public async Task<FlashCardCategoryPageDto> GetFlashCardCategoryAppPageAsync(int flashCardCategoryId, CancellationToken cancellationToken)
    {
        var flashCardCategory = await _flashCardCategoryRepository.GetLDtoAsync(flashCardCategoryId);
        if (flashCardCategory == null)
            throw new AppException("FlashCard Category Not Found", ApiResultStatusCode.NotFound);

        var page = new FlashCardCategoryPageDto { FlashCardCategory = flashCardCategory };
        foreach (var tag in page.FlashCardCategory.FlashCardTags)
        {
            page.FlashCardTags.Add(tag);
            var count = await _repositoryWrapper.SetRepository<FlashCard>().TableNoTracking.CountAsync(fc => fc.FlashCardTagId == tag.FlashCardTagId, cancellationToken);
            page.FlashCardTagCount++;
            tag.FlashCardCount = count;
            page.FlashCardCount += count;
        }
        var purchase = await _repositoryWrapper.SetRepository<FlashCardCategoryPurchase>()
            .TableNoTracking
            .FirstOrDefaultAsync(cp => cp.FlashCardCategoryId == flashCardCategoryId && cp.UserId == _currentUserService.UserId.ToInt(), cancellationToken);

        page.IsPurchased = purchase == null ? page.IsPurchased = false : page.IsPurchased = true;
        page.Rates = new ObservableCollection<FlashCardCategoryRate>(await _repositoryWrapper.SetRepository<FlashCardCategoryRate>().TableNoTracking.Where(r => r.IsConfirmed && r.FlashCardCategoryId == flashCardCategoryId).ToListAsync());
        return page;
    }

    public async Task<LeitnerBoxPageDto> GetLeitnerBoxAppPageAsync(CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
        if (user == null)
            throw new AppException("کاربر پیدا نشد", ApiResultStatusCode.NotFound);
        var userFlashCards = await _repositoryWrapper.SetRepository<UserFlashCardStatus>()
            .TableNoTracking
            .Where(ufc => ufc.UserId == user.Id)
            .Select(UserFlashCardStatusMapper.ProjectToLDto)
            .ToListAsync(cancellationToken);

        userFlashCards.ForEach(ufc => ufc.FlashCardAnswers.OrderBy(fca => fca.Row));
        var page = new LeitnerBoxPageDto
        {
            FlashCards = new ObservableCollection<UserFlashCardStatusLDto>(userFlashCards),
            FlashCardCategories = new ObservableCollection<FlashCardCategorySDto>(userFlashCards.GroupBy(ufc => ufc.FlashCardCategoryId)
        .Select(ufc => new FlashCardCategorySDto
        {
            Name = ufc.FirstOrDefault().FlashCardCategoryName,
            FlashCardCategoryId = ufc.Key
        })),
            FlashCardsTag = new ObservableCollection<FlashCardTagSDto>(userFlashCards.GroupBy(ufc => ufc.FlashCardTagId)
        .Select(ufc => new FlashCardTagSDto()
        {
            Name = ufc.FirstOrDefault().FlashCardTagName,
            FlashCardTagId = ufc.Key,
            FlashCardCategoryId = ufc.FirstOrDefault().FlashCardCategoryId
        })),
            TodayFlashCards = new ObservableCollection<UserFlashCardStatusLDto>(userFlashCards.Where(ufc => ufc.NextReviewAt.Date <= DateTime.Today.Date)),
            TotalTodayFlashCard = userFlashCards.Count(ufc => ufc.FlashCardStatus != Domain.Enums.FlashCardStatus.Archived && ufc.FlashCardStatus != Domain.Enums.FlashCardStatus.Done && ufc.NextReviewAt.Date <= DateTime.Today.Date),
            TotalFlashCard = userFlashCards.Count,
            TotalDoneFlashCard = userFlashCards.Count(ufc => ufc.FlashCardStatus == Domain.Enums.FlashCardStatus.Done)
        };
        foreach (var grouping in userFlashCards.GroupBy(ufc => ufc.FlashCardStatus))
        {
            var box = new LeitnerBoxDto { Status = grouping.Key, FlashCardCount = grouping.Count() };
            foreach (var userFlashCard in grouping)
            {
                box.FlashCards.Add(userFlashCard);
            }

            page.LeitnerBoxes.Add(box);
        }
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step0) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step0, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step0) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step1) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step1, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step1) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step2) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step2, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step2) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step3) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step3, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step3) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step4) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step4, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step4) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step5) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step5, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step5) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step6) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step6, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step6) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Step7) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Step7, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Step7) });
        if (page.LeitnerBoxes.FirstOrDefault(b => b.Status == Domain.Enums.FlashCardStatus.Done) == null)
            page.LeitnerBoxes.Add(new LeitnerBoxDto { Status = Domain.Enums.FlashCardStatus.Done, FlashCardCount = page.FlashCards.Count(fc => fc.FlashCardStatus == Domain.Enums.FlashCardStatus.Done) });
        return page;
    }

    public async Task<ProfilePageDto> GetProfilePageAsync()
    {
        var page = new ProfilePageDto();
        var user = (await _userManager.FindByNameAsync(_currentUserService.UserName)).AdaptToSDto();
        if (user == null)
            throw new BaseApiException(ApiResultStatusCode.UnAuthorized, "کاربر پیدا نشد");
        page.User = user;
        var coursePurchaseCount = await _repositoryWrapper.SetRepository<CoursePurchase>().TableNoTracking
            .Where(cp => cp.UserId == page.User.Id)
            .CountAsync();
        var handoutPurchaseCount = await _repositoryWrapper.SetRepository<HandoutPurchase>().TableNoTracking
            .Where(cp => cp.UserId == page.User.Id)
            .CountAsync();
        page.PurchaseCount = handoutPurchaseCount + coursePurchaseCount;
        var identityImage = await _repositoryWrapper.SetRepository<UserIdentityImage>().TableNoTracking
            .FirstOrDefaultAsync(i => i.UserId == user.Id);
        page.User.UserIdentityImageFileName = identityImage?.FileName;
        page.User.DtoPassword = "******";
        return page;
    }

    public async Task<PurchasePageDto> GetPurchasePageAsync()
    {
        var page = new PurchasePageDto();
        var user = (await _userManager.FindByNameAsync(_currentUserService.UserName)).AdaptToSDto();
        if (user == null)
            throw new BaseApiException(ApiResultStatusCode.UnAuthorized, "کاربر پیدا نشد");

        var coursePurchase = await _repositoryWrapper.SetRepository<CoursePurchase>().TableNoTracking
            .Where(cp => cp.UserId == user.Id)
            .ToListAsync();
        foreach (var purchase in coursePurchase)
        {
            var course = await _repositoryWrapper.SetRepository<Course>().TableNoTracking
                .Where(cp => cp.CourseId == purchase.CourseId)
                .Select(CourseMapper.ProjectToSDto)
                .FirstOrDefaultAsync();
            page.Courses.Add(course);
        }
        return page;
    }

    public async Task<DashboardPageDto> GetAdminDashboardPageAsync(CancellationToken cancellationToken)
    {
        var page = new DashboardPageDto();
        page.LastPayments = await _repositoryWrapper.SetRepository<Payment>()
            .TableNoTracking
            .OrderByDescending(p=>p.CreatedAt)
            .Take(8)
            .Select(PaymentMapper.ProjectToSDto)
            .ToListAsync();
        page.LastUsers = await _userManager.Users.OrderByDescending(u => u.SignUpAt)
            .Take(8)
            .Select(UserMapper.ProjectToSDto)
            .ToListAsync();
        page.CourseCount = await _repositoryWrapper.SetRepository<Course>().TableNoTracking.CountAsync();
        page.FlashCardCategoryCount = await _repositoryWrapper.SetRepository<FlashCardCategory>().TableNoTracking.CountAsync();
        return page;
    }
}
