namespace CreditCardValidator
{
    [AttributeUsage(AttributeTargets.All)]
    internal class RegexAttribute : Attribute
    {
        public RegexAttribute(string expression)
        {
            Expression = expression;
        }

        public string Expression { get; }
    }
}
