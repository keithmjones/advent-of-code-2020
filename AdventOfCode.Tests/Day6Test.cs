using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day6Test
    {
        [Theory]
        [InlineData(
            new string[] { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b", "" },
            new string[] { "abc", "a b c", "ab ac", "a a a a", "b" })]
        public void CanCollate(string[] input, string[] expected)
        {
            var result = Arrays.Collate(input, " ");
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("abc", 3)]
        [InlineData("a b c", 3)]
        [InlineData("ab ac", 3)]
        [InlineData("a a a a", 1)]
        [InlineData("b", 1)]
        public void CanCountUniqueCharsExcludingSpaces(string value, int expected)
        {
            var day6 = new Day6();
            var result = day6.CountUniqueCharsExcludingSpaces(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b", "" }, 11)]
        [InlineData(new string[] { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b" }, 11)]
        public void CanSolvePart1(string[] input, int expected)
        {
            var day6 = new Day6();
            var result = day6.SolvePart1(input);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b", "" }, 6)]
        [InlineData(new string[] { "abc", "", "a", "b", "c", "", "ab", "ac", "", "a", "a", "a", "a", "", "b" }, 6)]
        public void CanSolvePart2(string[] input, int expected)
        {
            var day6 = new Day6();
            var result = day6.SolvePart2(input);
            Assert.Equal(expected, result);
        }
    }
}
