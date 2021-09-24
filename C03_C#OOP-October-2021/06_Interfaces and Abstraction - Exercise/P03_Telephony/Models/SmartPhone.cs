namespace Telephony.Models
{
    using Telephony.Common;
    using Telephony.Models.Interfaces;

    public class SmartPhone : IPhone, ISmartPhone
    {
        public string Call(string phoneNumber)
        {
            PhoneValidator.CallValidator(phoneNumber);

            return $"Calling... {phoneNumber}";
        }

        public string Browse(string siteUrl)
        {
            PhoneValidator.SiteValidator(siteUrl);

            return $"Browsing: {siteUrl}!";
        }
    }
}
