namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class FlashCardAnswer : ApiEntity
{
    [Key]
    public int FlashCardAnswerId { get; set; }
    public string Answer { get; set; }
    public int Row { get; set; }
    public bool IsTrue { get; set; }
    public int FlashCardId { get; set; }
    public FlashCard FlashCard { get; set; }
}