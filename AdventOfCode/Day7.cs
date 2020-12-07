using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day7: Day
    {
        private IEnumerable<string> data;

        public void ReadInputFile(string inputFile)
        {
            data = File.ReadAllLines(inputFile);
        }

        public int SolvePart1() => SolvePart1(data, "shiny gold");

        public int SolvePart2() => SolvePart2(data, "shiny gold");

        public int SolvePart1(IEnumerable<string> input, string bag) {
            LuggageProcessor graph = new LuggageProcessor();
            foreach (var line in input)
            {
                graph.ParseInput(line);
            }
            return graph.GetBag(bag).Containers.Count();
        }

        public int SolvePart2(IEnumerable<string> input, string bag) {
            LuggageProcessor graph = new LuggageProcessor();
            foreach (var line in input)
            {
                graph.ParseInput(line);
            }
            return graph.GetBag(bag).GetAllContents().Values.Sum();
        }
    }
}