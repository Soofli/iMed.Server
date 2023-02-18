namespace iMed.Domain.Entities;

public class HandoutPurchase : Purchase
{
    public int HandoutId { get; set; }
    public Handout Handout { get; set; }
}