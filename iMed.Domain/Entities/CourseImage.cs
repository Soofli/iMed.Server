namespace iMed.Domain.Entities;

public class CourseImage : Image
{
    public int CourseId { get; set; }
    public Course Course { get; set; }
}