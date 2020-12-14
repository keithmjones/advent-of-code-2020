using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day14Test
    {
        [Theory]
        [InlineData(new string[] {
            "mask = XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X",
            "mem[8] = 11",
            "mem[7] = 101",
            "mem[8] = 0",
        }, 165)]
        public void CanSolvePart1(string[] data, int expected)
        {
            var day = new Day14();
            var result = day.SolvePart1(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(new string[] {
            "mask = 000000000000000000000000000000X1001X",
            "mem[42] = 100",
            "mask = 00000000000000000000000000000000X0XX",
            "mem[26] = 1"
        }, 208)]
        public void CanSolvePart2(string[] data, int expected)
        {
            var day = new Day14();
            var result = day.SolvePart2(data);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("000000000000000000000000000000000000", 0, 0L)]
        [InlineData("000000000000000000000000000000000000", 1, 0L)]
        [InlineData("111111111111111111111111111111111111", 0, 68719476735L)]
        [InlineData("111111111111111111111111111111111111", 1, 68719476735L)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", 0, 0L)]
        [InlineData("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX", 1, 68719476735L)]
        public void TestMask(string bits, int defaultValue, UInt64 expected)
        {
            var day = new Day14();
            var result = day.Mask(bits, defaultValue);
            Assert.Equal(expected, result);
        }
    }
}
