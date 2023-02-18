namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class FlashCardTag : ApiEntity
{
    [Key]
    public int FlashCardTagId { get; set; }
    public string Name { get; set; }
    public int FlashCardCategoryId { get; set; }
    public FlashCardCategory FlashCardCategory { get; set; }
    public virtual ICollection<FlashCard> FlashCards { get; set; }
}