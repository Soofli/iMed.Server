namespace iMed.Domain.Dtos.SmalDtos;

public class FlashCardAnswerSDto : BaseDto<FlashCardAnswerSDto, FlashCardAnswer> 
{
    public int FlashCardAnswerId { get; set; }
    public string Answer { get; set; }
    public bool IsTrue { get; set; }
    public int FlashCardId { get; set; }
    public int Row { get; set; }

    public bool IsSelected { get; set; }
    public bool IsEnabled { get; set; } = true;
    public bool ShowResult { get; set; }

}