using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day2
{
    public static class Task2
    {
        public static string Solve(IEnumerable<string> input)
        {
            var lines = input.ToList();

            string x = null;
            int index = -1;

            for (var i = 0; i < lines.Count - 1; i++)
            {
                x = lines[i];

                for (var j = i + 1; j < lines.Count; j++)
                {
                    var y = lines[j];
                    index = FindDiffCharacterIndex(x, y);

                    if (index >= 0)
                    {
                        break;
                    }
                }

                if (index >= 0)
                {
                    break;
                }
            }

            if (index < 0)
            {
                throw new NotSupportedException();
            }

            var result = new StringBuilder(x.Length);
            for (var i = 0; i < index; i++)
            {
                result.Append(x[i]);
            }

            for (var i = index + 1; i < x.Length; i++)
            {
                result.Append(x[i]);
            }

            return result.ToString();
        }

        public static int FindDiffCharacterIndex(string x, string y)
        {
            var result = -1;
            if (x.Length != y.Length)
            {
                return result;
            }

            for (var i = 0; i < x.Length; i++)
            {
                if (x[i] != y[i])
                {
                    if (result < 0)
                    {
                        result = i;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }

            return result;
        }
    }
}
