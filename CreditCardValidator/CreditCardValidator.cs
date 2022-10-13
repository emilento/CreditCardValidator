using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CreditCardValidator
{
    internal class CreditCardValidator
    {
        private readonly string _creditCardNumber;

        public CreditCardValidator(string creditCardNumber)
        {
            _creditCardNumber = creditCardNumber.Replace(" ", string.Empty).Trim();
        }

        public CreditCardType Validate()
        {
            if (!IsValidUsingLuhn(_creditCardNumber))
            {
                throw new ValidationException("Credit Card number is invalid");
            }

            foreach (CreditCardType creditCardType in Enum.GetValues(typeof(CreditCardType)))
            {
                var regexAttribute = creditCardType.GetAttribute<RegexAttribute>();
                if (regexAttribute == null)
                {
                    continue;
                }

                var regex = new Regex(regexAttribute.Expression);
                if (regex.IsMatch(_creditCardNumber))
                {
                    return creditCardType;
                }
            }

            return CreditCardType.Unknown;
        }

        private static bool IsValidUsingLuhn(string digits)
        {
            return digits.All(char.IsDigit) &&
                digits.Reverse()
                    .Select(c => c - 48)
                    .Select((digit, i) => i % 2 == 0
                        ? digit
                        : ((digit *= 2) <= 9 ? digit : digit - 9))
                    .Sum() % 10 == 0;
        }
    }
}
