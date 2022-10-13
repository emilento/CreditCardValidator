namespace CreditCardValidator
{
    [AttributeUsage(AttributeTargets.All)]
    internal class LengthsAttribute : Attribute
    {
        public LengthsAttribute(params int[] lengths)
        {
            Lengths = lengths;
        }

        public int[] Lengths { get; }
    }
}
