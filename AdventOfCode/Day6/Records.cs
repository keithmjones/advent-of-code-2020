using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    public class Records
    {
        public static IEnumerable<string> Collate(IEnumerable<string> input, string join)
        {
            List<string> records = new List<string>();
            var currentRecord = "";
            foreach (var line in input)
            {
                if (line == "")
                {
                    if (currentRecord != "")
                    {
                        records.Add(currentRecord);
                        currentRecord = "";
                    }
                }
                else if (currentRecord == "")
                {
                    currentRecord = line;
                }
                else
                {
                    currentRecord = String.Concat(currentRecord, join, line);
                }
            }
            if (currentRecord != "")
            {
                records.Add(currentRecord);
            }
            return records;
        }
    }
}
