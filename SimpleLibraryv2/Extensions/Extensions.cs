namespace SimpleLibraryv2
{
    public static class Extensions
    {
        public static string ToUpperFirstLetter(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return value;
            }

            return char.ToUpper(value[0]) + value.Substring(1);
        }

    }
}
