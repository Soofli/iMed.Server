namespace iMed.Domain.Dtos.SmalDtos;
public class CourseSDto : BaseDto<CourseSDto,Course>
{
    public int CourseId { get; set; }
    public string Name { get; set; }
    public string Detail { get; set; }
    public string Teacher { get; set; }
    public string Reference { get; set; }
    public bool IsFree { get; set; }
    public long Price { get; set; }
    public bool IsSuggested { get; set; }
    public int CourseCategoryId { get; set; }
    public string CourseCategoryName { get; set; }
    public double RateAvg { get; set; }
    public string ImageFileName { get; set; }
    public bool IsPurchase { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}
