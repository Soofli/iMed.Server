namespace iMed.Core.Services.Contracts;

public interface IPurchaseService : IScopedDependency
{
    Task<bool> PurchaseCourseAsync(int courseId, CancellationToken cancellationToken);
    Task<bool> PurchaseFlashCardCategoryAsync(int flashCardCategoryId, CancellationToken cancellationToken);
}