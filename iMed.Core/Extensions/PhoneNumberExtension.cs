namespace iMed.Core.Extensions;

public static class PhoneNumberExtension
{
    public static string GetVerifyFromPhoneNumber(string phoneNumber)
    {
        var last4Digit = phoneNumber.Substring(phoneNumber.Length - 5);
        if (int.TryParse(last4Digit, out int digitsResult))
        {
            digitsResult = (((((digitsResult * 3) + 152) * 2)/5)*7);
            if (digitsResult > 9999)
                digitsResult = digitsResult / 10;
            return digitsResult.ToString();
        }

        throw new AppException("Wrong Phone Number");
    }
}