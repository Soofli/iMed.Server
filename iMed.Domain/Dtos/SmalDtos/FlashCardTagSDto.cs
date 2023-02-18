namespace iMed.Domain.Dtos.SmalDtos;

public class FlashCardTagSDto : BaseDto<FlashCardTagSDto,FlashCardTag>
{
    public int FlashCardTagId { get; set; }
    public string Name { get; set; }
    public int FlashCardCategoryId { get; set; }
    public bool IsSelected { get; set; }
    public string ImageFileName { get; set; }
    public int FlashCardCount { get; set; }
}