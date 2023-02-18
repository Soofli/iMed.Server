namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class Payment : ApiEntity
{
    [Key]
    public int PaymentId { get; set; }
    public long Amount { get; set; }
    public string TransactionCode { get; set; }
    public string Mobile { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public DateTime PaymentTime { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}