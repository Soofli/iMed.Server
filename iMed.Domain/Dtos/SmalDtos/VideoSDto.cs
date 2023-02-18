namespace iMed.Domain.Dtos.SmalDtos;

public class VideoSDto : BaseDto<VideoSDto,Video>
{
    public int VideoId { get; set; }
    public string Name { get; set; }
    public int Row { get; set; }
    public double VideoTime { get; set; }
    public string FileLocation { get; set; }
    public string FileName { get; set; }
    public int CourseId { get; set; }
    public bool IsPurchase { get; set; }
    public bool IsFree { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}