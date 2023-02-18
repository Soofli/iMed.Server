namespace iMed.Repos.Repositories.Contracts;

public interface IPurchaseRepository : IReadRepository<Purchase>,IWriteRepository<Purchase>, IScopedDependency
{
    public Task<List<CoursePurchaseSDto>> GetCoursePurchasesAsync(DateTime startAt, DateTime endAt, string userFullName=null, string courseName=null,CancellationToken cancellationToken=default);
    public Task<List<CoursePurchaseSDto>> GetCoursePurchasesAsync(int page = 0, CancellationToken cancellationToken =default);
    public Task<CoursePurchaseSDto> GetCoursePurchaseAsync(int purchaseId,CancellationToken cancellationToken=default);
    public Task DeleteCoursePurchaseAsync(int purchaseId,CancellationToken cancellationToken=default);


    public Task<List<FlashCardCategoryPurchaseSDto>> GetFlashCardCategoryPurchasesAsync(int page = 0 , CancellationToken cancellationToken = default);
    public Task<List<FlashCardCategoryPurchaseSDto>> GetFlashCardCategoryPurchasesAsync(DateTime startAt, DateTime endAt, string userFullName = null, string flashCardCategoryName = null, CancellationToken cancellationToken = default);
    public Task<FlashCardCategoryPurchaseSDto> GetFlashCardCategoryPurchaseAsync(int purchaseId, CancellationToken cancellationToken = default);
    public Task DeleteFlashCardPurchaseAsync(int purchaseId, CancellationToken cancellationToken = default);
}