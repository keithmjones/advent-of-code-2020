using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day8Test
    {
        [Theory]
        [InlineData(
            new string[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            }, 5)]
        public void CanSolvePart1(string[] program, int expected)
        {
            var day8 = new Day8();
            var result = day8.SolvePart1(program);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new string[]
            {
                "nop +0",
                "acc +1",
                "jmp +4",
                "acc +3",
                "jmp -3",
                "acc -99",
                "acc +1",
                "jmp -4",
                "acc +6"
            }, 8)]
        public void CanSolvePart2(string[] program, int expected)
        {
            var day8 = new Day8();
            var result = day8.SolvePart2(program);
            Assert.Equal(expected, result);
        }
    }
}
