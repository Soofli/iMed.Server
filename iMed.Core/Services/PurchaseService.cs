using iMed.Domain.Enums;
using FlashCard = iMed.Domain.Entities.FlashCard;

namespace iMed.Core.Services;

public class PurchaseService : IPurchaseService
{
    private readonly ICurrentUserService _currentUserService;
    private readonly UserManager<User> _userManager;
    private readonly IRepositoryWrapper _repositoryWrapper;

    public PurchaseService(ICurrentUserService currentUserService,UserManager<User> userManager,IRepositoryWrapper repositoryWrapper)
    {
        _currentUserService = currentUserService;
        _userManager = userManager;
        _repositoryWrapper = repositoryWrapper;
    }
    public async Task<bool> PurchaseCourseAsync(int courseId,CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
        if (user == null)
            throw new AppException("کاربر مورد نظر پیدا نشد",ApiResultStatusCode.NotFound);
        var course = await _repositoryWrapper.SetRepository<Course>().TableNoTracking
            .FirstOrDefaultAsync(c => c.CourseId == courseId, cancellationToken);
        if (course == null)
            throw new BaseApiException(ApiResultStatusCode.NotFound,"دوره موردنظر پیدا نشد");
        var dbPurchaseCourse = await _repositoryWrapper.SetRepository<CoursePurchase>()
            .TableNoTracking
            .FirstOrDefaultAsync(c=>c.CourseId==courseId && c.UserId==user.Id, cancellationToken);
        if(dbPurchaseCourse!=null)
            throw new BaseApiException(ApiResultStatusCode.BadRequest, "شما قبلا این دوره را خریداری نمونده اید");
        if (user.WalletBalance < course.Price)
            throw new BaseApiException(ApiResultStatusCode.WalletBalanceNoEnough, "موجودی کیف پول شما کمتر از قیمت دوره می باشد برای خرید دوره نخست موجودی کیف پول خود را افزایش دهید");
        user.WalletBalance -= course.Price;
        await _userManager.UpdateAsync(user);
        var purchaseCourse = new CoursePurchase
        {
            CourseId = courseId,
            Price = course.Price,
            UserId = user.Id,
            IsFree = course.Price == 0,
        };
        await _repositoryWrapper.SetRepository<CoursePurchase>().AddAsync(purchaseCourse, cancellationToken);
        return true;
    }

    public async Task<bool> PurchaseFlashCardCategoryAsync(int flashCardCategoryId, CancellationToken cancellationToken)
    {
        try
        {
            var user = await _userManager.FindByNameAsync(_currentUserService.UserName);
            if (user == null)
                throw new AppException("کاربر مورد نظر پیدا نشد", ApiResultStatusCode.NotFound);
            var flashCardCategory = await _repositoryWrapper.SetRepository<FlashCardCategory>().TableNoTracking
                .FirstOrDefaultAsync(c => c.FlashCardCategoryId == flashCardCategoryId, cancellationToken);
            if (flashCardCategory == null)
                throw new BaseApiException(ApiResultStatusCode.NotFound, "دسته فلش کارت موردنظر پیدا نشد");
            var dbPurchaseFlashCard = await _repositoryWrapper.SetRepository<FlashCardCategoryPurchase>()
                .TableNoTracking
                .FirstOrDefaultAsync(c => c.FlashCardCategoryId == flashCardCategoryId && c.UserId == user.Id, cancellationToken);
            if (dbPurchaseFlashCard != null)
                throw new BaseApiException(ApiResultStatusCode.BadRequest, "شما قبلا این دسته فلش کارت را خریداری نمونده اید");
            if (user.WalletBalance < flashCardCategory.Price)
                throw new BaseApiException(ApiResultStatusCode.WalletBalanceNoEnough, "موجودی کیف پول شما کمتر از قیمت دسته فلش کارت می باشد برای خرید دوره نخست موجودی کیف پول خود را افزایش دهید");
            user.WalletBalance -= flashCardCategory.Price;
            await _userManager.UpdateAsync(user);
            var categoryPurchase = new FlashCardCategoryPurchase()
            {
                FlashCardCategoryId = flashCardCategoryId,
                Price = flashCardCategory.Price,
                UserId = user.Id,
                IsFree = flashCardCategory.Price == 0,
                
            };
            await _repositoryWrapper.SetRepository<FlashCardCategoryPurchase>().AddAsync(categoryPurchase, cancellationToken);

            var tags = await _repositoryWrapper.SetRepository<FlashCardTag>().TableNoTracking
                .Where(fc => fc.FlashCardCategoryId == flashCardCategoryId).ToListAsync(cancellationToken);
            var flashCards = new List<FlashCard>();
            foreach (var flashCardTag in tags)
            {
                flashCards.AddRange(await _repositoryWrapper.SetRepository<FlashCard>().TableNoTracking
                    .Where(fc => fc.FlashCardTagId == flashCardTag.FlashCardTagId).ToListAsync(cancellationToken));
            }
            foreach (var flashCard in flashCards)
            {
                var userFlashCard = new UserFlashCardStatus
                {
                    UserId = user.Id,
                    FlashCardId = flashCard.FlashCardId,
                    FlashCardStatus = FlashCardStatus.Step0,
                    NextReviewAt = DateTime.Now,

                };
                await _repositoryWrapper.SetRepository<UserFlashCardStatus>().AddAsync(userFlashCard, cancellationToken);
            }
            return true;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
}