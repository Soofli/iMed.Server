namespace iMed.Domain.Dtos.LargDtos;

public class UserFlashCardStatusLDto : BaseDto<UserFlashCardStatusLDto, UserFlashCardStatus>
{
    public int UserFlashCardStatusId { get; set; }
    public int FlashCardTagId { get; set; }
    public int FlashCardId { get; set; }
    public int FlashCardCategoryId { get; set; }
    public FlashCardStatus FlashCardStatus { get; set; }
    public bool IsArchive { get => FlashCardStatus == FlashCardStatus.Archived; }
    public FlashCardType FlashCardType { get; set; }
    public DateTime NextReviewAt { get; set; }
    public string Question { get; set; }
    public string LongAnswer { get; set; }
    public List<FlashCardAnswerSDto> FlashCardAnswers { get; set; }
    public string FlashCardTagName { get; set; }
    public string FlashCardCategoryName { get; set; }
    public bool IsMultiAnswer => FlashCardType == FlashCardType.MultiAnswer ? true : false;
    public bool ShowLongAnswer { get; set; }
    public bool IsSelected { get; set; }
}