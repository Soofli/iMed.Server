namespace iMed.Domain.Entities;

public class Rate :ApiEntity
{
    [Key]
    public int RateId { get; set; }
    public string RateMessage { get; set; }
    public string Author { get; set; }
    public int Score { get; set; }
    public bool IsConfirmed { get; set; }
}