using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T9Spelling
{
    public class T9
    {
        private static readonly Dictionary<char, string> T9Dict = new Dictionary<char, string>
        {
            {'a', "2"}, {'b', "22"}, {'c', "222"}, 
            {'d', "3"}, {'e', "33"}, {'f', "333"}, 
            {'g', "4"}, {'h', "44"}, {'i', "444"}, 
            {'j', "5"}, {'k', "55"}, {'l', "555"}, 
            {'m', "6"}, {'n', "66"}, {'o', "666"}, 
            {'p', "7"}, {'q', "77"}, {'r', "777"}, {'s', "7777"}, 
            {'t', "8"}, {'u', "88"}, {'v', "888"},
            {'w', "9"}, {'x', "99"}, {'y', "999"}, {'z', "9999"},
            {' ', "0"}
        };
        private const string LowLatinChars = "abcdefghigklmnopqrstuvwxyz ";

        /// <summary>
        /// Encode string using T9 rules
        /// </summary>
        public static string EncodeString(string inputString)
        {
            if (String.IsNullOrEmpty(inputString))  // Min 1 character in string 
                throw new ArgumentNullException("Input string is null of empty");
            if (inputString.Any(x => !LowLatinChars.Contains(x)))
                throw new ArgumentException("One or more elements aren't a low letter of space");

            var result = new List<char>();
            foreach (var code in inputString.Select(letter => T9Dict[letter]))
            {
                if (code.Last() == result.LastOrDefault())
                    result.Add(' ');
                result.AddRange(code.ToCharArray());
            }
            return String.Join("", result);
        }
    }
}
