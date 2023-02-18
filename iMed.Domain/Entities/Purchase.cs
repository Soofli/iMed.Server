namespace iMed.Domain.Entities;

public class Purchase : ApiEntity
{
    [Key]
    public int PurchaseId { get; set; }
    public long Price { get; set; }
    public bool IsFree { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
    
}