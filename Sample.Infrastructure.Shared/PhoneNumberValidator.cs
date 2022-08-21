using System.Text.RegularExpressions;

namespace Sample.Infrastructure.Shared
{
    public static class PhoneNumberValidator
    {
        public static bool IsValid(string phoneNumber)
        {
            if (string.IsNullOrEmpty(phoneNumber)) return false;
            if (phoneNumber.Length < 10) return false;
            var isValid = Regex.IsMatch(phoneNumber,
                "(0|\\+98)?([ ]|-|[()]){0,2}9[1|2|3|4]([ ]|-|[()]){0,2}(?:[0-9]([ ]|-|[()]){0,2}){8}");
            return isValid;
        }
    }
}