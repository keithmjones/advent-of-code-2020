using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Arrays
    {
        public static string[] Collate(string[] input, string join)
        {
            List<string> collated = new List<string>();
            var oldIndex = 0;
            var index = 0;
            do
            {
                index = Array.IndexOf(input, "", oldIndex);
                if (index < 0 && input.Length > oldIndex)
                {
                    index = input.Length;
                }
                if (index >= 0)
                {
                    if (index > 0)
                    {
                        var len = index - oldIndex;
                        var copy = new string[len];
                        Array.Copy(input, oldIndex, copy, 0, len);
                        collated.Add(String.Join(join, copy));
                    }
                    oldIndex = index + 1;
                }
            }
            while (index >= 0 && oldIndex < input.Length);
            return collated.ToArray();
        }
    }
}