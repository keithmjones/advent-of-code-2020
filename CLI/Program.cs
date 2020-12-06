using System;
using System.IO;
using AdventOfCode;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            int dayNumber = 0;
            string filename = "input";
            if (args.Length > 0)
            {
                Int32.TryParse(args[0], out dayNumber);
                if (args.Length > 1)
                {
                    filename = args[1];
                }
            }
            if (dayNumber < 1 || dayNumber > 25)
            {
                Console.Error.WriteLine("Day number must be between 1 and 25");
                Environment.Exit(1);
            }
            string path = $"data/day/{dayNumber}/{filename}.txt";
            if (!File.Exists(path))
            {
                Console.Error.WriteLine("File '{0}' does not exist.", path);
                Environment.Exit(2);
            }
            Day day = DayClass.NewDay(dayNumber);
            if (day == null) {
                Console.WriteLine("No solution found.");
            }
            else
            {
                day.ReadInputFile(path);
                Console.WriteLine("Part 1: {0}", day.SolvePart1());
                Console.WriteLine("Part 2: {0}", day.SolvePart2());
            }
        }
    }
}
