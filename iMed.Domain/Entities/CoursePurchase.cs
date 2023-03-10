namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class CoursePurchase : Purchase
{
    public int CourseId { get; set; }
    public Course Course { get; set; }
}