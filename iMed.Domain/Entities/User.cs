namespace iMed.Domain.Entities;

[AdaptTwoWays("[name]SDto", IgnoreAttributes = new[] { typeof(AdaptIgnoreAttribute) }, MapType = MapType.Map | MapType.MapToTarget | MapType.Projection)]
[GenerateMapper]
public class User : BaseUser
{
    public long WalletBalance { get; set; }
    public string IdentityCode { get; set; }
    public string StudentCode { get; set; }
    public bool IsConfirmed { get; set; }
    public double Score { get; set; }
    public DateTime SignUpAt { get; set; }
    public UserIdentityImage UserIdentityImage { get; set; }
    public ICollection<Payment> Payments { get; set; }
    public ICollection<CoursePurchase> VideoPurchases { get; set; }
    public ICollection<HandoutPurchase> HandoutPurchases { get; set; }
    public ICollection<FlashCardSubmittedAnswer> SubmittedAnswers { get; set; }
}