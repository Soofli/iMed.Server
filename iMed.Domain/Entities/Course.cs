using Mapster;

namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[AdaptTwoWays("[name]LDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class Course : ApiEntity
{
    public int CourseId { get; set; }
    public bool IsSuggested { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Teacher { get; set; }
    public string Reference { get; set; }
    public bool IsFree { get; set; }
    public long Price { get; set; }
    public int CourseCategoryId { get; set; }
    public double RateAvg { get; set; }
    public CourseCategory CourseCategory { get; set; }
    public CourseImage Image { get; set; }
    public ICollection<Video> Videos { get; set; }
    public ICollection<CourseHandout> Handouts { get; set; }
    public ICollection<CourseRate> CourseRates { get; set; }
    public ICollection<CoursePurchase> CoursePurchases { get; set; }
}
