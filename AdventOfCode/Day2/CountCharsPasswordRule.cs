using System.Linq;

namespace AdventOfCode
{
    public class CountCharsPasswordRule: IPasswordRule
    {
        public int MinChars { get; }
        public int MaxChars { get; }
        public char CharToTest { get; }

        public CountCharsPasswordRule(int min, int max, char chr) => (MinChars, MaxChars, CharToTest) = (min, max, chr);

        public bool IsValidPassword(string password)
        {
            int count = password.Count(chr => chr == CharToTest);
            return (count >= MinChars && count <= MaxChars);
        }

        public override string ToString() => $"{MinChars}-{MaxChars} {CharToTest}";
    }
}
