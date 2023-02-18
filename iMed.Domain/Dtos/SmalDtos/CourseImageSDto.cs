namespace iMed.Domain.Dtos.SmalDtos;

public class CourseImageSDto : BaseDto<CourseImageSDto, CourseImage>
{
    public int ImageId { get; set; }
    public string Name { get; set; }
    public string FileLocation { get; set; }
    public string FileName { get; set; }
}