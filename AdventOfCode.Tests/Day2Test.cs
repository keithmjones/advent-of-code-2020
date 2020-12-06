using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day2Test
    {
        [Theory]
        [InlineData(new string[] {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        }, typeof(CountCharsPasswordRule), 2)]
        [InlineData(new string[] {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        }, typeof(PositionCharsPasswordRule), 1)]
        public void CanSolve(string[] passwords, Type ruleType, int expected)
        {
            var day2 = new Day2();
            var result = day2.Solve(passwords, ruleType);
            Assert.Equal(expected, result);
        }
    }
}
