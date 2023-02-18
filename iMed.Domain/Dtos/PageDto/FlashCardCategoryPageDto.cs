namespace iMed.Domain.Dtos.PageDto;

public class FlashCardCategoryPageDto
{
    public FlashCardCategoryLDto FlashCardCategory { get; set; }
    public int FlashCardCount { get; set; }
    public int FlashCardTagCount { get; set; }
    public bool IsPurchased { get; set; }
    public ObservableCollection<FlashCardTagSDto> FlashCardTags { get; set; } = new();
    public ObservableCollection<FlashCardCategoryRate> Rates { get; set; } = new();
}