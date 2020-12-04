using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of number values from the input file
            string inputFile = "data/day/4/input.txt";
            IEnumerable<string> input = File.ReadLines(inputFile);

            var part1 = new SimplePassportValidator();
            var part2 = new ComplexPassportValidator();

            var passport = new Passport();
            foreach (var line in input) {
                if (line == "") {
                    part1.Validate(passport);
                    part2.Validate(passport);
                    passport = new Passport();
                } else {
                    passport.AddLine(line);
                }
            }
            part1.Validate(passport);
            part2.Validate(passport);

            Console.WriteLine("Part 1 answer: {0}", part1.Count);
            Console.WriteLine("Part 2 answer: {0}", part2.Count);
        }
    }
}
