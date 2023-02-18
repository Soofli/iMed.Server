namespace iMed.Domain.Dtos.SmalDtos;

public class CourseCategorySDto : BaseDto<CourseCategorySDto,CourseCategory>
{
    public int CourseCategoryId { get; set; }
    public string Name { get; set; }
    public int CourseId { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}