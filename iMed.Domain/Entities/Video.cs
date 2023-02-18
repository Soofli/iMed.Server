namespace iMed.Domain.Entities;


[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class Video : ApiEntity
{
    [Key]
    public int VideoId { get; set; }
    public int Row { get; set; }
    public string Name { get; set; }
    public double VideoTime { get; set; }
    public string FileLocation { get; set; }
    public string FileName { get; set; }
    public bool IsFree { get; set; }
    public int CourseId { get; set; }
    public Course Course { get; set; }
}