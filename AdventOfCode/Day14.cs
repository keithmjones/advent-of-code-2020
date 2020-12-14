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

        public UInt64 Mask(string bits, int defaultValue = 0) => bits
            .ToCharArray()
            .Select(value => (UInt64) (value == 'X' ? defaultValue : value & 1))
            .Aggregate((UInt64) 0L, (first, next) => first << 1 | next);

        (UInt64, UInt64, UInt64) UpdateMask(string instruction)
        {
            var mask = instruction.Substring(7);
            var andMask = Mask(mask, 1);
            var orMask = Mask(mask);
            var floatMask = andMask ^ orMask;
            // Console.WriteLine("mask={0} and={1} or={2} float={3}",
            //     mask,
            //     Convert.ToString((Int64) andMask, 2),
            //     Convert.ToString((Int64) orMask, 2),
            //     Convert.ToString((Int64) floatMask, 2));
            return (andMask, orMask, floatMask);
        }

        public Dictionary<UInt64, UInt64> WriteMemory(Dictionary<UInt64, UInt64> memory, UInt64 address, UInt64 value)
        {
            if (memory.ContainsKey(address)) memory.Remove(address);
            memory.Add(address, value);
            // Console.WriteLine("address={0} value={1}", address, value);
            return memory;
        }

        List<UInt64> GetPossibleAddresses(
            UInt64 address,
            UInt64 floatMask
        )
        {
            List<UInt64> addresses = new List<UInt64>();
            int shift = 0;
            UInt64 bit = 0;
            do
            {
                bit = floatMask & (UInt64) (1 << shift);
                shift++;
            } while (bit == 0 && shift < 36);
            if (bit != 0)
            {
                addresses.AddRange(GetPossibleAddresses((address | bit) ^ bit, floatMask ^ bit)); // low range
                addresses.AddRange(GetPossibleAddresses(address | bit, floatMask ^ bit)); // high range
            }
            else
            {
                addresses.Add(address);
            }
            return addresses;
        }

        Dictionary<UInt64, UInt64> UpdateMemory(
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
                // Console.WriteLine("address={0} -> ({1} x {2}) value={3}",
                //     rawAddress,
                //     maskedAddress,
                //     Convert.ToString((Int64) floatMask, 2),
                //     rawValue);
                foreach (var address in GetPossibleAddresses(maskedAddress, floatMask))
                {
                    memory = WriteMemory(memory, address, rawValue);
                }
            }
            else
            {
                UInt64 value = rawValue & andMask | orMask;
                // Console.WriteLine("address={0} value={1} -> {2}", rawAddress, rawValue, value);
                memory = WriteMemory(memory, rawAddress, value);
            }
            return memory;
        }

        public Int64 SolvePart1(string[] data)
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
                    UpdateMemory(memory, instruction, andMask, orMask, floatMask, false);
                }
            }

            Console.WriteLine("Addresses used: {0}", memory.Values.Count);
            return memory.Values.Aggregate(0L, (first, next) => first + (Int64) next);
        }

        public Int64 SolvePart2(string[] data)
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
                    UpdateMemory(memory, instruction, andMask, orMask, floatMask, true);
                }
            }

            Console.WriteLine("Addresses used: {0}", memory.Values.Count);
            return memory.Values.Aggregate(0L, (first, next) => first + (Int64) next);
        }
    }
}