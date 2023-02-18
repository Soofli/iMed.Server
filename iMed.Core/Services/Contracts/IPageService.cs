namespace iMed.Core.Services.Contracts;

public interface IPageService : IScopedDependency
{
    Task<MainPageDto> GetMainPageAsync();
    Task<ProfilePageDto> GetProfilePageAsync();
    Task<PurchasePageDto> GetPurchasePageAsync();
    Task<SearchPageDto> GetSearchPageAsync(string search);
    Task<CoursePageDto> GetCoursePageAsync(int courseId);
    Task<FlashCardCategoryLDto> GetFlashCardCategoryAdminPageAsync(int flashCardCategoryId , CancellationToken cancellationToken);
    Task<DashboardPageDto> GetAdminDashboardPageAsync(CancellationToken cancellationToken);
    Task<FlashCardCategoryPageDto> GetFlashCardCategoryAppPageAsync(int flashCardCategoryId , CancellationToken cancellationToken);
    Task<LeitnerBoxPageDto> GetLeitnerBoxAppPageAsync(CancellationToken cancellationToken);
}