namespace iMed.Domain.Dtos.RequestDto;

public class SignUpRequestDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string VerifyCode { get; set; }
    public string StudentCode { get; set; }
    public string IdentityCode { get; set; }
}