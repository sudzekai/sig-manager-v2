namespace Shared.Internal
{
    public static class StringExtension
    {
        public static int ToInt(this string str)
            => int.Parse(str.Replace("_", ""));
    }
}
