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
            var (rules, yourTicket, nearbyTickets) = ReadData(data);
            return nearbyTickets.Aggregate(0L, (first, next) => first + GetTicketError(next, rules));
        }

        public Int64 GetTicketError(List<Int64> ticket, Dictionary<string, List<(Int64, Int64)>> rules)
        {
            foreach (var number in ticket)
            {
                var valid = false;
                foreach (var rule in rules.Values)
                {
                    valid = IsValidForRule(number, rule);
                    if (valid) break;
                }
                if (!valid)
                {
                    return number;
                }
            }
            return 0;
        }

        public bool IsValidField(Int64 number, Dictionary<string, List<(Int64, Int64)>> rules)
        {
            var valid = false;
            foreach (var rule in rules.Values)
            {
                valid = IsValidForRule(number, rule);
                if (valid) break;
            }
            return valid;
        }

        public Int64 SolvePart2(string[] data)
        {
            var (rules, yourTicket, nearbyTickets) = ReadData(data);
            nearbyTickets = nearbyTickets.Where(value => GetTicketError(value, rules) == 0).ToList();
            var fields = new Dictionary<int, List<string>>();
            var matchedFields = new Dictionary<string, int>();

            for (var index = 0; index < yourTicket.Count; index++)
            {
                fields[index] = new List<string>();
                foreach (var rule in rules)
                {
                    var valid = IsValidForRule(yourTicket[index], rule.Value);
                    if (valid)
                    {
                        foreach (var ticket in nearbyTickets)
                        {
                            valid = IsValidForRule(ticket[index], rule.Value);
                            if (!valid) break;
                        }
                    }
                    if (valid)
                    {
                        Console.WriteLine("Field #{0} is valid for '{1}'", index, rule.Key);
                        fields[index].Add(rule.Key);
                    }
                }
            }

            // Find the shortest list (hopefully of length 1), and exclude its values from every other list
            do {
                var minCount = fields.Values.Select(value => value.Count).Min();
                var smallestField = fields.Where(field => field.Value.Count == minCount).First();
                if (smallestField.Value.Count > 1)
                {
                    Console.WriteLine("Houston we have a problem");
                    break;
                }
                string fieldName = smallestField.Value[0];
                matchedFields[fieldName] = smallestField.Key;
                Console.WriteLine("Matched field #{0} to '{1}'", smallestField.Key, fieldName);
                fields.Remove(smallestField.Key);
                foreach (var field in fields)
                {
                    field.Value.Remove(fieldName);
                }
            } while (fields.Count > 0);
            var product = 1L;
            foreach (var field in matchedFields)
            {
                if (field.Key.StartsWith("departure "))
                {
                    product = product * yourTicket[field.Value];
                }
            }
            return product;
        }

        public bool IsValidForRule(Int64 number, List<(Int64, Int64)> rule)
        {
            bool valid = false;
            foreach (var (min, max) in rule) // range
            {
                if (number >= min && number <= max)
                {
                    valid = true;
                }
            }
            return valid;
        }

        public (Dictionary<string, List<(Int64, Int64)>>, List<Int64>, List<List<Int64>>) ReadData(string[] data)
        {
            var rules = new Dictionary<string, List<(Int64, Int64)>>();
            var yourTicket = new List<Int64>();
            var nearbyTickets = new List<List<Int64>>();
            var mode = Mode.Rules;
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
            return (rules, yourTicket, nearbyTickets);
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
    }
}
