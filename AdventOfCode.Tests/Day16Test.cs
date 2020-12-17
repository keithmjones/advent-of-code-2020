using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day16Test
    {
        [Theory]
        [InlineData(new string[] {
            "class: 1-3 or 5-7",
            "row: 6-11 or 33-44",
            "seat: 13-40 or 45-50",
            "",
            "your ticket:",
            "7,1,14",
            "",
            "nearby tickets:",
            "7,3,47",
            "40,4,50",
            "55,2,20",
            "38,6,12"
        }, 71)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new Day16();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }
    }
}
