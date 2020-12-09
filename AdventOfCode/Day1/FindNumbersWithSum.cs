using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    public class FindNumbersWithSum
    {
        public static Int64 Find(IEnumerable<Int64> ints, int howManyIntsToSum, Int64 requiredSum)
        {
            if (howManyIntsToSum == 0 || !ints.Any()) return 0;
            var head = ints.First();
            var tail = ints.Skip(1);
            if (howManyIntsToSum == 1)
            {
                if (head == requiredSum) return head;
            }
            else
            {
                var result = Find(tail, howManyIntsToSum - 1, requiredSum - head);
                if (result != 0) return head * result;
            }
            return Find(tail, howManyIntsToSum, requiredSum);
        }
    }
}
