namespace iMed.Domain.Dtos.SmalDtos;

public class CourseRateSDto : BaseDto<CourseRateSDto,CourseRate>
{
    public int RateId { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public string RateMessage { get; set; }
    public string Author { get; set; }
    public bool IsConfirmed { get; set; }
    public int Score { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}