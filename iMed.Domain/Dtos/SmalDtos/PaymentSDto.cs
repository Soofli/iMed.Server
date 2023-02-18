namespace iMed.Domain.Dtos.SmalDtos;

public class PaymentSDto:BaseDto<PaymentSDto,Payment>
{
    public int PaymentId { get; set; }
    public long Amount { get; set; }
    public string TransactionCode { get; set; }
    public string Mobile { get; set; }
    public string Description { get; set; }
    public string CardNumber { get; set; }
    public string UserFirstName { get; set; }
    public string UserLastName { get; set; }
    public string UserFullName => UserFirstName + " " + UserLastName;
    public DateTime PaymentTime { get; set; }
    public long FishNumber { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public PersianDateTime CreationPersianDate => new PersianDateTime(CreatedAt);
}