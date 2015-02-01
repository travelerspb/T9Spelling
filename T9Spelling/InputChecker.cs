using System;

namespace T9Spelling
{
    public class InputChecker
    {
        public static void CheckData(string[] data)
        {
            int count;
            var answer = Int32.TryParse(data[0], out count);

            if (!answer)
                throw new ArgumentException("Unknown tests cases amount");
            if (count < 1 || count > 100)
                throw new ArgumentOutOfRangeException("Tests whould be 1 <= N <= 100");
            if (count != data.Length - 1)
                throw new ArgumentException("Expected test cases N different from actual");
        }
    }
}