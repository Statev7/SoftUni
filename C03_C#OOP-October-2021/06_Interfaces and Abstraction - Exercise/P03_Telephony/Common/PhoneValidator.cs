namespace Telephony.Common
{
    using System;

    public static class PhoneValidator
    {
        private const string INVALID_PHONE_ERROR_MESSAGE = "Invalid number!";
        private const string INVALID_SITE_URL_ERROR_MESSAGE = "Invalid URL!";

        public static void CallValidator(string phone)
        {
            for (int i = 0; i < phone.Length; i++)
            {
                if (char.IsLetter(phone[i]))
                {
                    throw new ArgumentException(INVALID_PHONE_ERROR_MESSAGE);
                }
            }
        }
        public static void SiteValidator(string siteUrl)
        {
            for (int i = 0; i < siteUrl.Length; i++)
            {
                if (char.IsDigit(siteUrl[i]))
                {
                    throw new ArgumentException(INVALID_SITE_URL_ERROR_MESSAGE);
                }
            }
        }
    }
}
