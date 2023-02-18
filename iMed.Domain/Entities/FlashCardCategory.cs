namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[AdaptTwoWays("[name]LDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class FlashCardCategory : ApiEntity
{
    [Key]
    public int FlashCardCategoryId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Author { get; set; }
    public long Price { get; set; }
    public bool IsFree { get; set; }
    public bool IsSuggested { get; set; }
    public double RateAvg { get; set; }
    public bool IsActive { get; set; }
    public FlashCardCategoryImage Image { get; set; }
    public ICollection<FlashCardTag> FlashCardTags { get; set; }
}