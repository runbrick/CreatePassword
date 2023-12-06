using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreatePassword
{
    public class PasswordGenerator
    {
        private const string LowerCase = "abcdefghijklmnopqrstuvwxyz";
        private const string UpperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private const string Digits = "0123456789";
        private const string SpecialCharacters = "!@#$%";

        /// <summary>
        /// 生成密码
        /// </summary>
        /// <param name="length">长度</param>
        /// <param name="excludeCharacters">排除字符串</param>
        /// <param name="isLowerCase">需要小写英文</param>
        /// <param name="isUpperCase">需要大写英文</param>
        /// <param name="isDigits">需要数字</param>
        /// <param name="isSpecialCharacters">需要特殊字符</param>
        /// <returns>生成的密码</returns>
        public static string GeneratePassword(
            int length = 10, 
            string excludeCharacters = "",
            bool isLowerCase = false,
            bool isUpperCase = false,
            bool isDigits = false,
            bool isSpecialCharacters = false)
        {
            var random = new Random();
            string characters = "";

            if (isLowerCase) { characters += LowerCase; }
            if (isUpperCase) { characters += UpperCase; }
            if (isDigits) { characters += Digits; }
            if (isSpecialCharacters) { characters += SpecialCharacters; }

            if (characters == string.Empty)
            {
                return "开玩笑？什么都不选让我给你生成。";
            }

            characters = ExcludeCharacters(characters, excludeCharacters);

            return new string(Enumerable.Repeat(characters, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private static string ExcludeCharacters(string characters, string exclude)
        {
            return new string(characters.Where(c => !exclude.Contains(c)).ToArray());
        }
    }
}
