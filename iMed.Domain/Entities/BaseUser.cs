namespace iMed.Domain.Entities;

public enum Gender
{
    Mail,
    Female
}

public class BaseUser : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public Gender Gender { get; set; }
}