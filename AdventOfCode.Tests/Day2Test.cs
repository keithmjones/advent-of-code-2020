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
        }, 2)]
        public void CanSolveCountCharsPasswordRule(string[] passwords, int expected)
        {
            var day2 = new Day2();
            var result = day2.Solve<CountCharsPasswordRule>(passwords);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "1-3 a: abcde",
            "1-3 b: cdefg",
            "2-9 c: ccccccccc"
        }, 1)]
        public void CanSolvePositionCharsPasswordRule(string[] passwords, int expected)
        {
            var day2 = new Day2();
            var result = day2.Solve<PositionCharsPasswordRule>(passwords);
            Assert.Equal(expected, result);
        }
    }
}
