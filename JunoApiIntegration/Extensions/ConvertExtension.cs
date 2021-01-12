using System;
using System.Text;

namespace JunoApiIntegration.Extensions
{
    internal static class ConvertExtension
    {
        public static string Base64Encode(this string text)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(text);
            return Convert.ToBase64String(plainTextBytes);
        }
    }
}
