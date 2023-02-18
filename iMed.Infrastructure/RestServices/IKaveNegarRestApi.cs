namespace iMed.Infrastructure.RestServices;

public interface IKaveNegarRestApi
{

    [Post("/{apiKey}/verify/lookup.json")]
    Task<KaveNegarResponse> SendVerify(string apiKey,[Query]string receptor,[Query]string token,[Query]string token2,[Query]string template);
    [Post("/{apiKey}/sms/send.json")]
    Task<KaveNegarResponse> SendSms(string apiKey, [Query] string receptor, [Query] string message,[Query]string sender);
}