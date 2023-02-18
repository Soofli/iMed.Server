namespace iMed.Infrastructure.Services;

public class SmsService : ISmsService
{
    private readonly IRestApiWrapper _restApiWrapper;

    public SmsService(IRestApiWrapper restApiWrapper)
    {
        _restApiWrapper = restApiWrapper;
    }
    public async Task SendVerifyCodeAsync(string phoneNumber, string verifyCode)
    {
        var rest = await _restApiWrapper.KaveNegarRestApi.SendVerify(
            "4F697144502B44374A72713150437A6F784C433861667464554F366F5A64495A754A417551444E374330773D", phoneNumber,
            verifyCode, null, "phoneNumberVerify");

        if (rest.Return.status != 200)
            throw new BaseApiException(ApiResultStatusCode.SendSmsError, rest.Return.message);
    }

    public async Task SendForgerPasswordAsync(string phoneNumber, string newPassword)
    {

        var rest = await _restApiWrapper.KaveNegarRestApi.SendVerify(
            "4F697144502B44374A72713150437A6F784C433861667464554F366F5A64495A754A417551444E374330773D", phoneNumber,
            newPassword, null, "forgetPassword");

        if (rest.Return.status != 200)
            throw new BaseApiException(ApiResultStatusCode.SendSmsError, rest.Return.message);
    }

    public async Task SendSmsAsync(string phoneNumber, string message)
    {

        var rest = await _restApiWrapper.KaveNegarRestApi.SendSms(
            "4F697144502B44374A72713150437A6F784C433861667464554F366F5A64495A754A417551444E374330773D", phoneNumber, message, "1000900090099");

        if (rest.Return.status != 200)
            throw new BaseApiException(ApiResultStatusCode.SendSmsError, rest.Return.message);
    }
}

