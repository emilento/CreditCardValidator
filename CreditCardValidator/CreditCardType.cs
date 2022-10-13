namespace CreditCardValidator
{
    public enum CreditCardType : byte
    {
        Unknown,

        [Lengths(15)]
        [Regex("^(34|37)")]
        AMEX,

        [Lengths(16)]
        [Regex("^(6011)")]
        Discover,

        [Lengths(16)]
        [Regex("^(51|52|53|54|55)")]
        MasterCard,

        [Lengths(13, 16)]
        [Regex("^(4)")]
        Visa
    }
}
