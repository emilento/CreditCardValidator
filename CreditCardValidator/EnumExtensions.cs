namespace CreditCardValidator
{
    public static class EnumExtensions
    {
        public static TAttribute? GetAttribute<TAttribute>(this Enum value) 
            where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }
            
            return enumType
                .GetField(name)?
                .GetCustomAttributes(false)
                .OfType<TAttribute>()
                .SingleOrDefault();
        }
    }
}
