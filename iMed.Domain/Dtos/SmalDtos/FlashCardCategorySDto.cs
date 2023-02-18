namespace iMed.Domain.Dtos.SmalDtos;

public class FlashCardCategorySDto : BaseDto<FlashCardCategorySDto,FlashCardCategory>
{
    public int FlashCardCategoryId { get; set; }
    public string FlashCardCategoryName { get; set; }
    public string Detail { get; set; }
    public string Author { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public bool IsFree { get; set; }
    public bool IsSuggested { get; set; }
    public bool IsPurchase { get; set; }
    public double RateAvg { get; set; }
    public string ImageFileName { get; set; }
    public bool IsSelected { get; set; }
    public bool IsActive { get; set; }
    public int FlashCardCount { get; set; }
}