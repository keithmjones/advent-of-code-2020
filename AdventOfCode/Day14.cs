using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day14: Day
    {
        private string[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        public Int64 SolvePart1(string[] data) => Solve(data, false);

        public Int64 SolvePart2(string[] data) => Solve(data, true);

        public Int64 Solve(string[] data, bool updateAddresses)
        {
            UInt64 andMask = UInt64.MaxValue;
            UInt64 orMask = 0L;
            UInt64 floatMask = 0L;
            var memory = new Dictionary<UInt64, UInt64>();
            foreach (var instruction in data)
            {
                if (instruction.StartsWith("mask"))
                {
                    (andMask, orMask, floatMask) = UpdateMask(instruction);
                }
                else if (instruction.StartsWith("mem"))
                {
                    UpdateMemory(memory, instruction, andMask, orMask, floatMask, updateAddresses);
                }
            }

            var sum = memory.Aggregate((UInt64) 0L, (first, next) => first + next.Value);
            return (Int64) sum;
        }

        (UInt64, UInt64, UInt64) UpdateMask(string instruction)
        {
            var mask = instruction.Substring(7);
            var andMask = Mask(mask, 1);
            var orMask = Mask(mask);
            var floatMask = andMask ^ orMask;
            return (andMask, orMask, floatMask);
        }

        public UInt64 Mask(string bits, int defaultValue = 0) => bits
            .ToCharArray()
            .Select(value => (UInt64) (value == 'X' ? defaultValue : value & 1))
            .Aggregate((UInt64) 0L, (first, next) => first << 1 | next);

        void UpdateMemory(
            Dictionary<UInt64, UInt64> memory,
            string instruction,
            UInt64 andMask,
            UInt64 orMask,
            UInt64 floatMask,
            bool updateAddresses)
        {
            int idx0 = instruction.IndexOf('[') + 1;
            int idx1 = instruction.IndexOf(']', idx0);
            UInt64 rawAddress = (UInt64) Int64.Parse(instruction.Substring(idx0, idx1 - idx0));
            UInt64 rawValue = (UInt64) Int64.Parse(instruction.Substring(idx1 + 4));
            if (updateAddresses)
            {
                var maskedAddress = rawAddress | orMask;
                foreach (var address in GetPossibleAddresses(maskedAddress, floatMask))
                {
                    WriteMemory(memory, address, rawValue);
                }
            }
            else
            {
                UInt64 value = rawValue & andMask | orMask;
                WriteMemory(memory, rawAddress, value);
            }
        }

        List<UInt64> GetPossibleAddresses(
            UInt64 address,
            UInt64 floatMask
        )
        {
            List<UInt64> addresses = new List<UInt64>();
            if (floatMask == 0L)
            {
                addresses.Add(address);
            }
            else
            {
                int shift = 0;
                UInt64 bit = 0;
                do
                {
                    bit = floatMask & (UInt64) (1L << shift);
                    shift++;
                } while (bit == 0 && shift < 36);
                var lowAddress = address & ~bit;
                var nextFloatMask = floatMask & ~bit;
                addresses.AddRange(GetPossibleAddresses(lowAddress, nextFloatMask)); // low range
                addresses.AddRange(GetPossibleAddresses(lowAddress ^ bit, nextFloatMask)); // high range
            }
            return addresses;
        }

        public void WriteMemory(Dictionary<UInt64, UInt64> memory, UInt64 address, UInt64 value)
        {
            memory.Remove(address);
            memory.Add(address, value);
        }
    }
}
