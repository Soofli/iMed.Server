namespace iMed.Server.Controllers.V1;

[ApiVersion("1")]
[Authorize(AuthenticationSchemes = "Bearer")]
public class PurchaseController : BaseController
{
    private readonly IPurchaseService _purchaseService;
    private readonly IPurchaseRepository _purchaseRepository;

    public PurchaseController(IPurchaseService purchaseService, 
        IPurchaseRepository purchaseRepository)
    {
        _purchaseService = purchaseService;
        _purchaseRepository = purchaseRepository;
    }

    [HttpPost("FlashCardCategory")]
    public async Task<IActionResult> PurchaseFlashCardCategory([FromQuery] int flashcardCategoryId, CancellationToken cancellationToken)
        => Ok(await _purchaseService.PurchaseFlashCardCategoryAsync(flashcardCategoryId, cancellationToken));

    [HttpGet("FlashCardCategory")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetFlashCardCategoryPurchases([FromQuery]int page ,CancellationToken cancellationToken)
        => Ok(await _purchaseRepository.GetFlashCardCategoryPurchasesAsync(page,cancellationToken));


    [HttpGet("FlashCardCategory/Filter")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetFlashCardCategoryPurchases([FromQuery] long startAt, [FromQuery] long endAt , [FromQuery] string userFullName, [FromQuery] string objectName, CancellationToken cancellationToken)
        => Ok(await _purchaseRepository.GetFlashCardCategoryPurchasesAsync(DateTimeExtensions.UnixTimeStampToDateTime(startAt), DateTimeExtensions.UnixTimeStampToDateTime(endAt), userFullName, objectName, cancellationToken));

    [HttpGet("FlashCardCategory/{id}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetFlashCardCategoryPurchase(int id, CancellationToken cancellationToken)
        => Ok(await _purchaseRepository.GetFlashCardCategoryPurchaseAsync(id, cancellationToken));

    [HttpDelete("FlashCardCategory/{id}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> DeleteFlashCardCategoryPurchase(int id, CancellationToken cancellationToken)
    {
        await _purchaseRepository.DeleteFlashCardPurchaseAsync(id, cancellationToken);
        return Ok();
    }




    [HttpPost("Course")]
    public async Task<IActionResult> PurchaseCourse([FromQuery] int courseId, CancellationToken cancellationToken)
        => Ok(await _purchaseService.PurchaseCourseAsync(courseId, cancellationToken));

    [HttpGet("Course")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetCoursePurchases([FromQuery] int page, CancellationToken cancellationToken)
        => Ok(await _purchaseRepository.GetCoursePurchasesAsync(page,cancellationToken));


    [HttpGet("Course/Filter")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetCoursePurchases([FromQuery] long startAt, [FromQuery] long endAt, [FromQuery] string userFullName, [FromQuery] string objectName, CancellationToken cancellationToken)
        => Ok(await _purchaseRepository.GetCoursePurchasesAsync(DateTimeExtensions.UnixTimeStampToDateTime(startAt), DateTimeExtensions.UnixTimeStampToDateTime(endAt), userFullName, objectName, cancellationToken));

    [HttpGet("Course/{id}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> GetCoursePurchase(int id, CancellationToken cancellationToken)
        => Ok(await _purchaseRepository.GetCoursePurchaseAsync(id, cancellationToken) );

    [HttpDelete("Course/{id}")]
    [ClaimRequirement(CustomClaims.IsAdmin, "True")]
    public async Task<IActionResult> DeleteCoursePurchase(int id, CancellationToken cancellationToken)
    {
        await _purchaseRepository.DeleteCoursePurchaseAsync(id, cancellationToken);
        return Ok();
    }
}