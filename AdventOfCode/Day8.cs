using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day8: Day
    {
        private string[] data;

        public void ReadInputFile(string inputFile)
        {
            data = File.ReadAllLines(inputFile).ToArray();
        }

        public int SolvePart1() => SolvePart1(data);

        public int SolvePart2() => SolvePart2(data);

        public int SolvePart1(string[] program) {
            (var terminated, var accumulator, var programCounter) = Run(program);
            return accumulator;
        }

        public int SolvePart2(string[] program) {
            var totalJumpInstructions = program.Where(value => value.StartsWith("jmp")).Count();
            for (var i = 0; i < totalJumpInstructions; i++)
            {
                (var terminated, var accumulator, var programCounter) = Run(program, i);
                if (terminated)
                {
                    Console.Error.WriteLine("T={0} A={1} PC={2} LEN={3} J={4}", terminated, accumulator, programCounter, program.Length, i);
                    return accumulator;
                }
            }
            Console.Error.WriteLine("Program did not terminate :-(");
            return 0;
        }

        public (bool, int, int) Run(string[] program, int jumpInstructionToIgnore = -1)
        {
            var visited = new bool[program.Length];
            var terminated = false;
            var accumulator = 0;
            var programCounter = 0;
            var nextJumpInstruction = 0;
            do
            {
                visited[programCounter] = true;
                string[] instruction = program[programCounter].Split(' ');
                int value = Int32.Parse(instruction[1].Substring(1));
                if (instruction[1][0] == '-')
                {
                    value = -value;
                }
                if (instruction[0] == "acc")
                {
                    accumulator += value;
                }
                if (instruction[0] == "jmp")
                {
                    programCounter += nextJumpInstruction == jumpInstructionToIgnore ? 1 : value;
                    nextJumpInstruction++;
                }
                else
                {
                    programCounter++;
                }
                terminated = programCounter < 0 || programCounter >= program.Length;
            } while (!terminated && !visited[programCounter]);
            return (terminated, accumulator, programCounter);
       }
    }
}