using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day11: Day
    {
        private char[][] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).Select(str => str.ToCharArray()).ToArray();
        }

        public Int64 SolvePart1() => Solve(input, false);

        public Int64 SolvePart2() => Solve(input, true);

        public Int64 Solve(char[][] room, bool part2) {
            reset(room);
            int generation = 0;
            int changedCells = 0;
            int occupiedSeats = 0;
            do {
                generation++;
                (changedCells, occupiedSeats) = generate(room, part2);
            } while (changedCells != 0);
            return occupiedSeats;
        }

        public int[] dx = { 0, 1, 1, 1, 0, -1, -1, -1 };

        public int[] dy = { -1, -1, 0, 1, 1, 1, 0, -1 };

        public (int, int) generate(char[][] room, bool part2)
        {
            // Pass 1: work out what cells to update
            var rows = room.Length;
            var columns = room[0].Length;
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    var cell = room[row][column];
                    if (cell != '.')
                    {
                        var visibleOccupiedSeats = 0;
                        for (int dir = 0; dir < 8; dir++)
                        {
                            var x = column;
                            var y = row;
                            var edge = false;
                            do {
                                x += dx[dir];
                                y += dy[dir];
                                edge = x < 0 || x >= columns || y < 0 || y >= rows;
                                if (!edge && (room[y][x] == '#' || room[y][x] == 'x'))
                                {
                                    visibleOccupiedSeats++;
                                }
                            } while (part2 && !edge && room[y][x] == '.');
                        }
                        if (cell == 'L' && visibleOccupiedSeats == 0)
                        {
                            room[row][column] = '*'; // seat will become occupied
                        }
                        if (cell == '#' && visibleOccupiedSeats >= (part2 ? 5 : 4))
                        {
                            room[row][column] = 'x'; // seat will become empty
                        }
                    }
                }
            }
            // Pass 2: perform update
            var changedCells = 0;
            var occupiedSeats = 0;
            for (var row = 0; row < rows; row++)
            {
                for (var column = 0; column < columns; column++)
                {
                    var cell = room[row][column];
                    if (cell == '*')
                    {
                        room[row][column] = '#';
                        occupiedSeats++;
                        changedCells++;
                    }
                    else if (cell == 'x')
                    {
                        room[row][column] = 'L';
                        changedCells++;
                    }
                    else if (cell == '#')
                    {
                        occupiedSeats++;
                    }
                }
            }
            return (changedCells, occupiedSeats);
        }

        public void reset(char[][] room)
        {
            for (var row = 0; row < room.Length; row++)
            {
                for (var column = 0; column < room[0].Length; column++)
                {
                    if (room[row][column] == '#')
                    {
                        room[row][column] = 'L';
                    }
                }
            }
        }
    }
}