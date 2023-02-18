namespace iMed.Infrastructure.Models.RestApi.IDPay;

public class IDPayVerifyPaymentResponse
{
        public int status { get; set; }
        public string track_id { get; set; }
        public string id { get; set; }
        public string order_id { get; set; }
        public string amount { get; set; }
        public string date { get; set; }
}

public class IDPayVerifyPaymentResponsePayment
{
    public string track_id { get; set; }
    public string amount { get; set; }
    public string card_no { get; set; }
    public string hashed_card_no { get; set; }
    public string date { get; set; }
}

public class IDPayVerifyPaymentResponseVerify
{
    public string date { get; set; }
}