using System;
using System.Collections.Generic;
using System.IO;

namespace AdventOfCode
{
    public class Day4: Day
    {
        private IEnumerable<string> input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1()
        {
            return Solve(input, new SimplePassportValidator());
        }

        public Int64 SolvePart2()
        {
            return Solve(input, new ComplexPassportValidator());
        }

        public int Solve(IEnumerable<string> input, PassportValidator validator)
        {
            var passport = new Passport();
            foreach (var line in input)
            {
                if (line == "")
                {
                    validator.Validate(passport);
                    passport = new Passport();
                }
                else
                {
                    passport.AddLine(line);
                }
            }
            validator.Validate(passport);
            return validator.Count;
        }
    }
}
