namespace iMed.Domain.Dtos.SmalDtos;

public class FlashCardSDto : BaseDto<FlashCardSDto, FlashCard>
{
    public int FlashCardId { get; set; }
    public string Question { get; set; }
    public string FlashCardTagName { get; set; }
    public int FlashCardCategoryId { get; set; }
    public int FlashCardTagId { get; set; }
    public string ImageFileName { get; set; }
    public string LongAnswer { get; set; }
    public DateTime NextReviewAt { get; set; }
    public FlashCardStatus FlashCardStatus { get; set; }
    public List<FlashCardAnswerSDto> FlashCardAnswers { get; set; }
}