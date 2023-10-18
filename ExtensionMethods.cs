namespace Dart_Class_Generator
{
    public static class ExtensionMethods
    {
        public static string FirstCharToLowerCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLowerInvariant(str[0]) + str.Substring(1);

            return str;
        }
        public static string FirstCharToUpperCase(this string str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsLower(str[0]))
                return str.Length == 1 ? char.ToUpper(str[0]).ToString() : char.ToUpperInvariant(str[0]) + str.Substring(1);

            return str;
        }
    }
}
