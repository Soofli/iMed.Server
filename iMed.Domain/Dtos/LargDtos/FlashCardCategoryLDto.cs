namespace iMed.Domain.Dtos.LargDtos;

public class FlashCardCategoryLDto:BaseDto<FlashCardCategoryLDto,FlashCardCategory>
{
    public int FlashCardCategoryId { get; set; }
    public string FlashCardCategoryName { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Author { get; set; }
    public long Price { get; set; }
    public string ImageFileName { get; set; }
    public bool IsSuggested { get; set; }
    public double RateAvg { get; set; }
    public bool IsFree { get; set; }
    public bool IsActive { get; set; }
    public string FlashCardCategory { get; set; }
    public FlashCardCategoryImage Image { get; set; }
    public List<FlashCardTagSDto> FlashCardTags { get; set; }
    public List<FlashCardSDto> FlashCards { get; set; }
}