using System;
using System.IO;
using System.Linq;

namespace AdventOfCode
{
    public class Day12: Day
    {
        private string[] input;

        public void ReadInputFile(string inputFile)
        {
            input = File.ReadAllLines(inputFile).ToArray();
        }

        public Int64 SolvePart1() => SolvePart1(input);

        public Int64 SolvePart2() => SolvePart2(input);

        int[] dx = { 0, 1, 0, -1 };

        int[] dy = { -1, 0, 1, 0 };

        public Int64 SolvePart1(string[] data)
        {
            int x = 0;
            int y = 0;
            int dir = 1; // 0=N 1=E 2=S 3=W
            foreach (string s in data)
            {
                var action = s[0];
                var magnitude = Int32.Parse(s.Substring(1));
                if (action == 'L' || action == 'R')
                {
                    var dirchange = magnitude / 90;
                    if (action == 'L') dirchange = 4 - dirchange;
                    dir += dirchange;
                    dir %= 4;
                    Console.WriteLine("{0}{1} -> new dir: {2}", action, magnitude, dir);
                }
                else
                {
                    int movedir;
                    if (action == 'F')
                    {
                        movedir = dir;
                    }
                    else
                    {
                        movedir = "NESW".IndexOf(action);
                    }
                    x += dx[movedir] * magnitude;
                    y += dy[movedir] * magnitude;
                    Console.WriteLine("{0}{1} -> new position: {2} {3}, {4} {5}",
                                      action,
                                      magnitude,
                                      x < 0 ? "west" : "east",
                                      Math.Abs(x),
                                      y < 0 ? "north" : "south",
                                      Math.Abs(y));
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }

        public Int64 SolvePart2(string[] data)
        {
            int x = 0;
            int y = 0;
            int waypoint_x = 10;
            int waypoint_y = -1;
            foreach (string s in data)
            {
                var action = s[0];
                var magnitude = Int32.Parse(s.Substring(1));
                if (action == 'L' || action == 'R')
                {
                    var dirchange = magnitude / 90;
                    if (action == 'L') dirchange = 4 - dirchange;
                    (waypoint_x, waypoint_y) = Translate(waypoint_x, waypoint_y, dirchange);
                    Console.WriteLine("{0}{1} -> new waypoint relative position: ({2}, {3})", action, magnitude, waypoint_x, waypoint_y);
                }
                else if (action == 'F')
                {
                    x += waypoint_x * magnitude;
                    y += waypoint_y * magnitude;
                    Console.WriteLine("{0}{1} -> new ship position: {2} {3}, {4} {5}",
                                      action,
                                      magnitude,
                                      x < 0 ? "west" : "east",
                                      Math.Abs(x),
                                      y < 0 ? "north" : "south",
                                      Math.Abs(y));
                }
                else
                {
                    var movedir = "NESW".IndexOf(action);
                    waypoint_x += dx[movedir] * magnitude;
                    waypoint_y += dy[movedir] * magnitude;
                    Console.WriteLine("{0}{1} -> new waypoint relative position: ({2}, {3})", action, magnitude, waypoint_x, waypoint_y);
                }
            }
            return Math.Abs(x) + Math.Abs(y);
        }

        int[][] x_translate = { new int[] { 0, -1 }, new int[] { -1, 0 }, new int[] { 0, 1 } };

        int[][] y_translate = { new int[] { 1, 0 }, new int[] { 0, -1 }, new int[] { -1, 0 } };

        (int, int) Translate(int current_x, int current_y, int rotation)
        {
            var idx = (rotation % 4) - 1;
            var new_x = idx < 0 ? current_x : current_x * x_translate[idx][0] + current_y * x_translate[idx][1];
            var new_y = idx < 0 ? current_y : current_x * y_translate[idx][0] + current_y * y_translate[idx][1];
            return (new_x, new_y);
        }
    }
}