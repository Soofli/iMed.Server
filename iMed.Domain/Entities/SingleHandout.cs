namespace iMed.Domain.Entities;

public class SingleHandout: Handout
{
    public ICollection<HandoutPurchase> HandoutPurchases { get; set; }
}