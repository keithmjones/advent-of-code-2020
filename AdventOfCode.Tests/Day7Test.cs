using System;
using Xunit;

namespace AdventOfCode.Tests
{
    public class Day7Test
    {
        [Theory]
        [InlineData(
            new string[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            }, "shiny gold", 4)]
        public void CanSolvePart1(string[] input, string bag, int expected)
        {
            var day7 = new Day7();
            var result = day7.SolvePart1(input, bag);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new string[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            }, "neon pink", 0)]
        public void CanSolvePart1WithNonExistentColor(string[] input, string bag, int expected)
        {
            var day7 = new Day7();
            var result = day7.SolvePart1(input, bag);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new string[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            }, "shiny gold", 32)]
        public void CanSolvePart2a(string[] input, string bag, int expected)
        {
            var day7 = new Day7();
            var result = day7.SolvePart2(input, bag);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new string[]
            {
                "light red bags contain 1 bright white bag, 2 muted yellow bags.",
                "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
                "bright white bags contain 1 shiny gold bag.",
                "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
                "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
                "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
                "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
                "faded blue bags contain no other bags.",
                "dotted black bags contain no other bags."
            }, "neon pink", 0)]
        public void CanSolvePart2aWithNonExistentColor(string[] input, string bag, int expected)
        {
            var day7 = new Day7();
            var result = day7.SolvePart2(input, bag);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new string[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            }, "shiny gold", 126)]
        public void CanSolvePart2b(string[] input, string bag, int expected)
        {
            var day7 = new Day7();
            var result = day7.SolvePart2(input, bag);
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(
            new string[]
            {
                "shiny gold bags contain 2 dark red bags.",
                "dark red bags contain 2 dark orange bags.",
                "dark orange bags contain 2 dark yellow bags.",
                "dark yellow bags contain 2 dark green bags.",
                "dark green bags contain 2 dark blue bags.",
                "dark blue bags contain 2 dark violet bags.",
                "dark violet bags contain no other bags."
            }, "neon pink", 0)]
        public void CanSolvePart2bWithNonExistentColor(string[] input, string bag, int expected)
        {
            var day7 = new Day7();
            var result = day7.SolvePart2(input, bag);
            Assert.Equal(expected, result);
        }
    }
}
