using System.ComponentModel.DataAnnotations;

namespace CreditCardValidator
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class RegexAttribute : ValidationAttribute
    {
        public RegexAttribute(string expression)
        {
            Expression = expression;
        }

        public string Expression { get; }
    }
}
