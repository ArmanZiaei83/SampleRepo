using System;

namespace Sample.Infrastructure.Shared.Validations
{
    public static class NationalCodeValidator
    {
        public static bool IsValid(string nationalCodeStr)
        {
            var nationalCode = Convert.ToInt64(nationalCodeStr);

            var minLength = 10000000L;
            var maxLength = 9999999999L;

            var parity = nationalCode % 10;
            var code = nationalCode / 10;
            if (nationalCode < minLength || nationalCode > maxLength)
                return false;

            long sum = 0;
            for (var position = 2; code != 0; position++)
            {
                sum += code % 10 * position;
                code /= 10;
            }

            var result = sum % 11;
            return result < 2 && parity == result ||
                   result >= 2 && 11 - result == parity;
        }
    }
}