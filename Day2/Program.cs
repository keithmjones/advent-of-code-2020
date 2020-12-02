using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get a list of number values from the input file
            string inputFile = "data/day/2/input.txt";
            IEnumerable<String> lines = File.ReadAllLines(inputFile);

            // Part 1
            int validPasswords1 = lines.Select(line => ParsePasswordWithRule(line, typeof(CountCharsPasswordRule)))
                                       .Where(value => value.IsValid())
                                       .Count();
            Console.WriteLine("Part 1: {0} valid passwords", validPasswords1);

            // Part 2
            int validPasswords2 = lines.Select(line => ParsePasswordWithRule(line, typeof(PositionCharsPasswordRule)))
                                       .Where(value => value.IsValid())
                                       .Count();
            Console.WriteLine("Part 2: {0} valid passwords", validPasswords2);
        }

        static PasswordWithRule ParsePasswordWithRule(string line, Type ruleType) {
            // Check that ruleType is an IPasswordRule
            if (!typeof(IPasswordRule).IsAssignableFrom(ruleType)) {
                throw new Exception("{0} is not an IPasswordRule");
            }

            // Parse arguments
            Regex rx = new Regex(@"(\d+)[-](\d+) (.)[:] (.+)", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            GroupCollection groups = rx.Matches(line)[0].Groups;
            int first = int.Parse(groups[1].Value);
            int second = int.Parse(groups[2].Value);
            char chr = groups[3].Value[0];
            string pass = groups[4].Value;

            // Turn into a PasswordWithRule
            ConstructorInfo ctor = ruleType.GetConstructor(new[] { typeof(int), typeof(int), typeof(char) });
            IPasswordRule rule = (IPasswordRule) ctor.Invoke(new object[] { first, second, chr });
            return new PasswordWithRule(rule, pass);
        }
    }
}
