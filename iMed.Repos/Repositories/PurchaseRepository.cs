using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace iMed.Repos.Repositories;

public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
{
    private readonly ILogger<PurchaseRepository> _logger;

    public PurchaseRepository(ApplicationContext dbContext, ICurrentUserService currentUserService,ILogger<PurchaseRepository> logger) : base(dbContext, currentUserService)
    {
        _logger = logger;
    }
    private IBaseRepository<T> SetRepository<T>() where T : ApiEntity => new BaseRepository<T>(DbContext, _currentUserService);



    public async Task<List<CoursePurchaseSDto>> GetCoursePurchasesAsync(DateTime startAt,DateTime endAt, string userFullName = null, string courseName = null, CancellationToken cancellationToken = default)
    {
        _logger.LogInformation($"DATAs : UserFullName : {userFullName} + courseName : {courseName} + StartAt : {startAt.ToString()} + EndAt : {endAt.ToString()}");
        List<CoursePurchaseSDto> purchaseSDtos = await SetRepository<CoursePurchase>()
            .TableNoTracking
            .Select(CoursePurchaseMapper.ProjectToSDto)
            .ToListAsync(cancellationToken);
        if (!userFullName.IsNullOrEmpty())
        {
            purchaseSDtos = purchaseSDtos
                .Where(p => (p.UserFirstName + " " + p.UserLastName).Contains(userFullName))
                .ToList();
        }
        if (!courseName.IsNullOrEmpty())
        {
            purchaseSDtos = purchaseSDtos
                .Where(p => p.CourseName.Contains(courseName))
                .ToList();
        }
        if (startAt.Date != DateTimeExtensions.UnixTimeStampToDateTime(0) && endAt.Date != DateTimeExtensions.UnixTimeStampToDateTime(0))
        {
            purchaseSDtos = purchaseSDtos
                .Where(p => p.CreatedAt.Date >= startAt.Date && p.CreatedAt.Date <= endAt.Date)
                .ToList();
        }
        _logger.LogInformation($"Return Datas : {purchaseSDtos.ToList()}");
        return purchaseSDtos.OrderByDescending(p=>p.CreatedAt).ToList();
    }

    public async Task<List<CoursePurchaseSDto>> GetCoursePurchasesAsync(int page = 0, CancellationToken cancellationToken = default)
    {
        var rtn = await SetRepository<CoursePurchase>()
            .TableNoTracking
            .OrderByDescending(p => p.CreatedAt)
            .Skip(page * 30)
            .Take(30)
            .Select(CoursePurchaseMapper.ProjectToSDto)
            .ToListAsync(cancellationToken);
        return rtn;
    }

    public async Task<CoursePurchaseSDto> GetCoursePurchaseAsync(int purchaseId, CancellationToken cancellationToken = default)
    {
        var purchase = await SetRepository<CoursePurchase>()
            .TableNoTracking
            .Where(c => c.PurchaseId == purchaseId)
            .Select(CoursePurchaseMapper.ProjectToSDto)
            .FirstOrDefaultAsync(cancellationToken);
        if (purchase == null)
            throw new BaseApiException(ApiResultStatusCode.NotFound, "خرید مورد نظر پیدا نشد");
        return purchase;
    }

    public async Task DeleteCoursePurchaseAsync(int purchaseId, CancellationToken cancellationToken = default)
    {
        var course = await SetRepository<CoursePurchase>()
            .TableNoTracking.FirstOrDefaultAsync(c => c.PurchaseId == purchaseId, cancellationToken);
        if (course == null)
            throw new BaseApiException(ApiResultStatusCode.NotFound, "خرید مورد نظر پیدا نشد");
        await SetRepository<CoursePurchase>().DeleteAsync(course, cancellationToken);
    }

    public async Task<List<FlashCardCategoryPurchaseSDto>> GetFlashCardCategoryPurchasesAsync(int page = 0, CancellationToken cancellationToken = default)
    {
        var rtn = await SetRepository<FlashCardCategoryPurchase>()
            .TableNoTracking
            .OrderByDescending(p => p.CreatedAt)
            .Skip(page * 30)
            .Take(30)
            .Select(FlashCardCategoryPurchaseMapper.ProjectToSDto)
            .ToListAsync(cancellationToken);
        return rtn;
    }

    public async Task<List<FlashCardCategoryPurchaseSDto>> GetFlashCardCategoryPurchasesAsync(DateTime startAt, DateTime endAt, string userFullName = null, string flashCardCategoryName = null, CancellationToken cancellationToken = default)
    {
        List<FlashCardCategoryPurchaseSDto> purchaseSDtos = await SetRepository<FlashCardCategoryPurchase>()
            .TableNoTracking
            .Select(FlashCardCategoryPurchaseMapper.ProjectToSDto)
            .ToListAsync(cancellationToken);
        if (!userFullName.IsNullOrEmpty())
        {
            purchaseSDtos = purchaseSDtos
                .Where(p => (p.UserFirstName + " " + p.UserLastName).Contains(userFullName))
                .ToList();
        }
        if (!flashCardCategoryName.IsNullOrEmpty())
        {
            purchaseSDtos = purchaseSDtos
                .Where(p => p.FlashCardCategoryName.Contains(flashCardCategoryName))
                .ToList();
        }
        if (startAt.Date != DateTimeExtensions.UnixTimeStampToDateTime(0) && endAt.Date != DateTimeExtensions.UnixTimeStampToDateTime(0))
        {
            purchaseSDtos = purchaseSDtos
                .Where(p => p.CreatedAt.Date >= startAt.Date && p.CreatedAt.Date <= endAt.Date)
                .ToList();
        }

        return purchaseSDtos.ToList();
    }

    public async Task<FlashCardCategoryPurchaseSDto> GetFlashCardCategoryPurchaseAsync(int purchaseId, CancellationToken cancellationToken = default)
    {
        var purchase = await SetRepository<FlashCardCategoryPurchase>()
            .TableNoTracking
            .Where(c => c.PurchaseId == purchaseId)
            .Select(FlashCardCategoryPurchaseMapper.ProjectToSDto)
            .FirstOrDefaultAsync(cancellationToken);
        if (purchase == null)
            throw new BaseApiException(ApiResultStatusCode.NotFound, "خرید مورد نظر پیدا نشد");
        return purchase;
        
    }

    public async Task DeleteFlashCardPurchaseAsync(int purchaseId, CancellationToken cancellationToken = default)
    {
        var purchase = await SetRepository<FlashCardCategoryPurchase>()
            .TableNoTracking.FirstOrDefaultAsync(c => c.FlashCardCategoryId == purchaseId, cancellationToken);
        if (purchase == null)
            throw new BaseApiException(ApiResultStatusCode.NotFound, "خرید مورد نظر پیدا نشد");
        await SetRepository<FlashCardCategoryPurchase>().DeleteAsync(purchase, cancellationToken);
    }
}