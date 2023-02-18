namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[AdaptTwoWays("[name]LDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class CourseCategory : ApiEntity
{
    [Key]
    public int CourseCategoryId { get; set; }
    public string Name { get; set; }
    public ICollection<Course> Courses { get; set; }
}