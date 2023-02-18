namespace iMed.Domain.Dtos.SmalDtos;

public class UserSDto : BaseDto<UserSDto, User>
{
    public int Id { get; set; }
    public long WalletBalance { get; set; }
    public string IdentityCode { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public double Score { get; set; }
    public DateTime BirthDate { get; set; }
    public bool IsConfirmed { get; set; }
    public Gender Gender { get; set; }
    public string StudentCode { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserIdentityImageFileName { get; set; }
    public string DtoPassword { get; set; }
}