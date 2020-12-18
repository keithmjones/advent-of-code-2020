using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day18Test
    {
        [Theory]
        [InlineData(new string[] {}, 0)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new DaySample();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {}, 0)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new DaySample();
            var result = day.SolvePart2(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("1 + 2 * 3 + 4 * 5 + 6", 71)]
        [InlineData("1 + (2 * 3) + (4 * (5 + 6))", 51)]
        [InlineData("2 * 3 + (4 * 5)", 26)]
        [InlineData("5 + (8 * 3 + 9 + 3 * 4 * 3)", 437)]
        [InlineData("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", 12240)]
        [InlineData("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", 13632)]
        public void CanEvaluateExpression(string source, int expected)
        {
            var exp = new Expression(source);
            var result = exp.Evaluate();
            Assert.Equal(expected, result);
        }
    }
}
