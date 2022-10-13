using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace CreditCardValidator
{
    internal class CreditCardValidator
    {
        private readonly string _creditCardNumber;

        public CreditCardValidator(string creditCardNumber)
        {
            _creditCardNumber = creditCardNumber;
        }

        public CreditCardType Validate()
        {
            if (!Luhn(_creditCardNumber))
            {
                throw new ValidationException("Credit Card number is invalid");
            }

            foreach (CreditCardType creditCardType in Enum.GetValues(typeof(CreditCardType)))
            {
                var memberInfo = typeof(CreditCardType).GetMember(typeof(CreditCardType).GetEnumName(creditCardType)!);
                var lengthsAttribute = memberInfo[0]
                    .GetCustomAttributes(typeof(LengthsAttribute), false)
                    .FirstOrDefault() as LengthsAttribute;

                if (lengthsAttribute == null)
                {
                    continue;
                }

                if (lengthsAttribute.Lengths.Contains(_creditCardNumber.Length))
                {
                    var regexAttribute = memberInfo[0]
                        .GetCustomAttributes(typeof(RegexAttribute), false)
                        .FirstOrDefault() as RegexAttribute;

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
            }

            return CreditCardType.Unknown;
        }

        private static bool Luhn(string digits)
        {
            return digits.All(char.IsDigit) &&
                digits.Reverse()
                    .Select(c => c - 48)
                    .Select((digit, i) => i % 2 == 0
                        ? digit
                        : ((digit *= 2) > 9 ? digit - 9 : digit))
                    .Sum() % 10 == 0;
        }

    }
}
