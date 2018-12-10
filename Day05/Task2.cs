using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Day05
{
    public static class Task2
    {
        public static int Solve(string input)
        {
            var test = new StringBuilder(input.Trim());
            Task1.React(test);

            input = test.ToString();

            var problemByChar = new Dictionary<char, int>();
            for (var i = 0; i < input.Length; i++)
            {
                var problem = char.ToLowerInvariant(input[i]);

                if (!problemByChar.ContainsKey(problem))
                {
                    test = new StringBuilder(input);
                    RemoveProblem(test, problem);

                    Task1.React(test);
                    problemByChar.Add(problem, test.Length);
                }
            }

            return problemByChar.Values.Min();
        }

        private static void RemoveProblem(StringBuilder input, char problemLower)
        {
            for (var i = 0; i < input.Length; i++)
            {
                var test = input[i];
                if (problemLower.Equals(test) || problemLower.Equals(char.ToLowerInvariant(test)))
                {
                    input.Remove(i, 1);
                    i--;
                }
            }
        }
    }
}
