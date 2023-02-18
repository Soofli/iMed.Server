namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class FlashCard : ApiEntity
{
    [Key]
    public int FlashCardId { get; set; }
    public string Question { get; set; }
    public FlashCardType FlashCardType { get; set; }
    public int FlashCardTagId { get; set; }
    public string LongAnswer { get; set; }
    public FlashCardTag FlashCardTag { get; set; }
    public virtual ICollection<FlashCardAnswer> FlashCardAnswers { get; set; }
    public virtual ICollection<UserFlashCardStatus> UserFlashCardStatus { get; set; }
    public virtual ICollection<FlashCardSubmittedAnswer> SubmittedAnswers { get; set; }
}