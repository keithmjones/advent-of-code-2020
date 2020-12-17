using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day17: Day
    {
        private string[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile);
        }

        public Int64 SolvePart1() => Solve(input, 6, 1);

        public Int64 SolvePart2() => Solve(input, 6, 13);

        public Int64 Solve(string[] data, int iterations, int max_w)
        {
            var (cubes, max_x, max_y, max_z) = GetCubeArray(data, iterations, max_w);
            for (int i = 0; i < iterations; i++)
            {
                cubes = Generate(cubes, max_x, max_y, max_z, max_w);
            }
            return CountCubes(cubes, max_x, max_y, max_z, max_w);
        }

        public (bool[][][][], int, int, int) GetCubeArray(string[] data, int iterations, int max_w)
        {
            var expansion = iterations * 2;
            var max_x = expansion + data[0].Length;
            var max_y = expansion + data.Length;
            var max_z = 1 + expansion + 1;
            var cubes = BlankArray(max_x, max_y, max_z, max_w);
            var w = max_w == 1 ? 0 : iterations;
            for (int y = 0; y < data.Length; y++)
            {
                for (int x = 0; x < data[y].Length; x++)
                {
                    cubes[x + iterations][y + iterations][iterations][w] = data[y][x] == '#';
                }
            }
            return (cubes, max_x, max_y, max_z);
        }

        public bool[][][][] BlankArray(int max_x, int max_y, int max_z, int max_w)
        {
            bool[][][][] cubes = new bool[max_x][][][];
            for (int x = 0; x < max_x; x++)
            {
                cubes[x] = new bool[max_y][][];
                for (int y = 0; y < max_y; y++)
                {
                    cubes[x][y] = new bool[max_z][];
                    for (int z = 0; z < max_z; z++)
                    {
                        cubes[x][y][z] = new bool[max_w];
                    }
                }
            }
            return cubes;
        }

        public bool[][][][] Generate(bool[][][][] cubes, int max_x, int max_y, int max_z, int max_w)
        {
            var newCubes = BlankArray(max_x, max_y, max_z, max_w);
            for (var x = 0; x < max_x; x++)
            {
                for (var y = 0; y < max_y; y++)
                {
                    for (var z = 0; z < max_z; z++)
                    {
                        for (var w = 0; w < max_w; w++)
                        {
                            var neighbours = CountNeighbours(cubes, x, y, z, w, max_x, max_y, max_z, max_w, 4);
                            if (neighbours == 3 || (cubes[x][y][z][w] && neighbours == 2))
                            {
                                newCubes[x][y][z][w] = true;
                            }
                        }
                    }
                }
            }
            return newCubes;
        }

        public int CountNeighbours(
            bool[][][][] cubes,
            int x,
            int y,
            int z,
            int w,
            int max_x,
            int max_y,
            int max_z,
            int max_w,
            int max_neighbours)
        {
            var neighbours = 0;
            var dxmin = x == 0 ? 0 : -1;
            var dymin = y == 0 ? 0 : -1;
            var dzmin = z == 0 ? 0 : -1;
            var dwmin = w == 0 ? 0 : -1;
            var dxmax = x + 1 == max_x ? 0 : 1;
            var dymax = y + 1 == max_y ? 0 : 1;
            var dzmax = z + 1 == max_z ? 0 : 1;
            var dwmax = w + 1 == max_w ? 0 : 1;
            for (var dx = dxmin; dx <= dxmax; dx++)
            {
                for (var dy = dymin; dy <= dymax; dy++)
                {
                    for (var dz = dzmin; dz <= dzmax; dz++)
                    {
                        for (var dw = dwmin; dw <= dwmax; dw++)
                        {
                            if (cubes[x + dx][y + dy][z + dz][w + dw] && (dx != 0 || dy != 0 || dz != 0 || dw != 0))
                            {
                                neighbours++;
                                if (neighbours == max_neighbours)
                                {
                                    return neighbours; // four is enough
                                }
                            }
                        }
                    }
                }
            }
            return neighbours;
        }

        public Int64 CountCubes(bool[][][][] cubes, int max_x, int max_y, int max_z, int max_w)
        {
            var count = 0L;
            for (var x = 0; x < max_x; x++)
            {
                for (var y = 0; y < max_y; y++)
                {
                    for (var z = 0; z < max_z; z++)
                    {
                        for (var w = 0; w < max_w; w++)
                        {
                            if (cubes[x][y][z][w])
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            return count;
        }

        public Int64 SolvePart2(string[] data) => 0;
    }
}
