namespace Telephony.Models
{
    using Telephony.Common;
    using Telephony.Models.Interfaces;

    public class StationaryPhone : IPhone
    {
        public string Call(string phoneNumber)
        {
            PhoneValidator.CallValidator(phoneNumber);

            return $"Dialing... {phoneNumber}";
        }
    }
}
