namespace iMed.Domain.Dtos.SmalDtos;

public class CoursePurchaseSDto : BaseDto<CoursePurchaseSDto,CoursePurchase>
{
    public int PurchaseId { get; set; }
    public long Price { get; set; }
    public bool IsFree { get; set; }
    public int UserId { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public int CourseId { get; set; }
    public string CourseName { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}