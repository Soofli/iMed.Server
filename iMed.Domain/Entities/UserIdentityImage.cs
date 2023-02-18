namespace iMed.Domain.Entities;

public class UserIdentityImage : Image
{
    public int UserId { get; set; }
    public User User { get; set; }
}