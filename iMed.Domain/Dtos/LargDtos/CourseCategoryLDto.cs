namespace iMed.Domain.Dtos.LargDtos;

public class CourseCategoryLDto : BaseDto<CourseCategoryLDto,CourseCategory>
{
    public int CourseCategoryId { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
    public List<CourseSDto> Courses { get; set; }

}