namespace iMed.Domain.Entities;

public class BaseRole : IdentityRole<int>
{
    public string Description { get; set; }
}