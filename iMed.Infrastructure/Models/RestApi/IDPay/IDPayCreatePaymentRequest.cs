namespace iMed.Infrastructure.Models.RestApi.IDPay;

public class IDPayCreatePaymentRequest
{
    public int Order_id { get; set; }
    public int Amount { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string Mail { get; set; }
    public string Desc { get; set; }
    public string Callback { get; set; }
}