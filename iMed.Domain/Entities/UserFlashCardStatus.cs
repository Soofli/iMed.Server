namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]LDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class UserFlashCardStatus : ApiEntity
{
    public int UserFlashCardStatusId { get; set; }
    public FlashCardStatus FlashCardStatus { get; set; }
    public DateTime NextReviewAt { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }
    public int FlashCardId { get; set; }
    public FlashCard FlashCard { get; set; }
}