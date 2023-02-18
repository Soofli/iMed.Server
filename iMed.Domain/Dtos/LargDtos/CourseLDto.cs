namespace iMed.Domain.Dtos.LargDtos;

public class CourseLDto : BaseDto<CourseLDto,Course>
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Teacher { get; set; }
    public string Reference { get; set; }
    public string ImageFileName { get; set; }
    public CourseImage Image { get; set; }
    public bool IsSuggested { get; set; }
    public bool IsFree { get; set; }
    public long Price { get; set; }
    public int CourseCategoryId { get; set; }
    public string CourseCategoryName { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
    public List<VideoSDto> Videos { get; set; }
    public List<CourseHandoutSDto> Handouts { get; set; }

}