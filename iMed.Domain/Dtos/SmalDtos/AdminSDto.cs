namespace iMed.Domain.Dtos.SmalDtos;

public class AdminSDto : BaseDto<AdminSDto, Admin>
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
    public string StudentCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string DtoPassword { get; set; }
}