namespace CreditCardValidator
{
    public enum CreditCardType : byte
    {
        Unknown,

        [Regex("^(34|37)\\d{15}")]
        AMEX,

        [Regex("^(6011)\\d{16}")]
        Discover,

        [Regex("^(51|52|53|54|55)\\d{16}")]
        MasterCard,

        [Regex("^(4)\\d{13,16}")]
        Visa
    }
}
