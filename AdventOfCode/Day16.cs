using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day16: Day
    {
        private string[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        enum Mode {
            Rules,
            YourTicket,
            NearbyTickets
        }

        public Int64 SolvePart1(string[] data)
        {
            var rules = new Dictionary<string, List<(Int64, Int64)>>();
            var yourTicket = new List<Int64>();
            var nearbyTickets = new List<List<Int64>>();
            var mode = Mode.Rules;
            var errorRate = 0L;
            foreach (string line in data)
            {
                if (line != "")
                {
                    if (line == "your ticket:")
                    {
                        mode = Mode.YourTicket;
                    }
                    else if (line == "nearby tickets:")
                    {
                        mode = Mode.NearbyTickets;
                    }
                    else if (mode == Mode.Rules)
                    {
                        var idx = line.IndexOf(":");
                        var field = line.Substring(0, idx);
                        var ranges = GetRanges(line.Substring(idx + 1));
                        rules[field] = ranges;
                    }
                    else if (mode == Mode.YourTicket)
                    {
                        yourTicket.AddRange(GetInts(line));
                    }
                    else if (mode == Mode.NearbyTickets)
                    {
                        nearbyTickets.Add(GetInts(line));
                    }
                }
            }

            foreach (var numbers in nearbyTickets) // nearby ticket
            {
                Console.WriteLine("Ticket: {0}", String.Join(',', numbers));
                foreach (var number in numbers) // ticket number
                {
                    foreach (var rule in rules.Values) // rule
                    {
                        foreach (var (min, max) in rule) // range
                        {
                            if (number < min || number > max)
                            {
                                Console.WriteLine("number {0} is less than {1} or greater than {2}", number, min, max);
                                //errorRate += number;
                            }
                        }
                    }
                }
            }
            return errorRate;
        }

        public List<(Int64, Int64)> GetRanges(string line)
        {
            var ranges = new List<(Int64, Int64)>();
            var idx = 0;
            do
            {
                var idx2 = line.IndexOf(" or ", idx);
                string range;
                if (idx2 >= 0)
                {
                    range = line.Substring(idx, idx2 - idx);
                    idx = idx2 + 4;
                }
                else
                {
                    range = line.Substring(idx);
                    idx = idx2;
                }
                var values = range.Split("-").Select(value => Int64.Parse(value)).ToArray();
                ranges.Add((values[0], values[1]));
            } while (idx >= 0);
            return ranges;
        }

        public List<Int64> GetInts(string line) => line.Split(",").Select(value => Int64.Parse(value)).ToList();

        public Int64 SolvePart2(string[] data) => 0;
    }
}