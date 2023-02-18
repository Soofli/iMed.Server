namespace iMed.Domain.Dtos.SmalDtos;

public class FlashCardCategoryPurchaseSDto : BaseDto<FlashCardCategoryPurchaseSDto, FlashCardCategoryPurchase>
{

    public int PurchaseId { get; set; }
    public long Price { get; set; }
    public bool IsFree { get; set; }
    public int UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public int FlashCardCategoryId { get; set; }
    public string FlashCardCategoryName { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}