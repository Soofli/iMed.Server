namespace iMed.Domain.Dtos.SmalDtos;
public class FlashCardCategoryRateSDto : BaseDto<FlashCardCategoryRateSDto,FlashCardCategoryRate>
{
    public int RateId { get; set; }
    public int FlashCardCategoryId { get; set; }
    public string FlashCardCategoryName { get; set; }
    public string RateMessage { get; set; }
    public string Author { get; set; }
    public bool IsConfirmed { get; set; }
    public int Score { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}
