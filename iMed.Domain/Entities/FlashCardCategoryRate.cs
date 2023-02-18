namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class FlashCardCategoryRate : Rate
{
    public int FlashCardCategoryId { get; set; }
    public FlashCardCategory FlashCardCategory { get; set; }
}
