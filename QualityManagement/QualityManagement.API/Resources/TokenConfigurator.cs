using System;
using System.Collections.Generic;

namespace QualityManagement.API.Resources
{
    public class TokenConfigurator
    {
        private static readonly List<string> AccessTokens = new List<string>();
        public static bool ValidToken(string token) => AccessTokens.Contains(token);
        public static string CreateToken()
        {
            string token = RandomStringToken();

            AccessTokens.Add(token);

            return token;
        }

        private static string RandomStringToken()
        {
            var chars = "abcdef0123456789";
            var stringChars = new char[36];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                if (i == 8 || i == 13 || i == 18 || i == 23)
                    stringChars[i] = '-';
                else 
                    stringChars[i] = chars[random.Next(chars.Length)];
            }

            return new String(stringChars);
        }
    }
}
