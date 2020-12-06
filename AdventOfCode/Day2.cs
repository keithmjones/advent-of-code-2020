using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day2: Day
    {
        private IEnumerable<string> lines;

        public void ReadInputFile(string inputFile)
        {
            // Get a list of passwords from the input file
            lines = File.ReadAllLines(inputFile);
        }

        public int SolvePart1()
        {
            // Validate passwords based on character counts
            return Solve(lines, typeof(CountCharsPasswordRule));
        }

        public int SolvePart2()
        {
            // Validate passwords based on exactly one character match in given positions
            return Solve(lines, typeof(PositionCharsPasswordRule));
        }

        public int Solve(IEnumerable<string> passwords, Type ruleType)
        {
            return passwords.Select(password => PasswordWithRule.Parse(password, ruleType))
                            .Where(password => password.IsValid())
                            .Count();
        }
    }
}