using System.Text.RegularExpressions;

namespace Sample.Infrastructure.Shared
{
    public static class PhoneNumberValidator
    {
        public static bool IsValid(string phoneNumber)
        {
            var mobileNumber = phoneNumber.TrimStart('0');
            var number = $"0{mobileNumber}";
            var pattern =
                new Regex(@"^(09)([0|1|2|3][1-9]{1}[0-9]{3}[0-9]{4})$");
            return pattern.IsMatch(number);
        }
    }
}