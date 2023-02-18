namespace iMed.Domain.Dtos.ResponseDto;

public class IncreaseInventoryResponseDto
{
    public string PaymentUrl { get; set; }
    public bool NeedToPayment { get; set; }
    public bool Increased { get; set; }
}