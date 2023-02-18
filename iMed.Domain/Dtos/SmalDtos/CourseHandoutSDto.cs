namespace iMed.Domain.Dtos.SmalDtos;

public class CourseHandoutSDto : BaseDto<CourseHandoutSDto, CourseHandout>
{
    public int HandoutId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string FileLocation { get; set; }
    public string FileName { get; set; }
    public bool IsPurchase { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}