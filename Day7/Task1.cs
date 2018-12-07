using System;
using System.Collections.Generic;
using System.Text;

namespace Day7
{
    public static class Task1
    {
        public static string Solve(IEnumerable<string> input)
        {
            var steps = Parser.Parse(input);
            var result = new StringBuilder(steps.Count);

            Step next;
            while ((next = MoveNext(steps)) != null)
            {
                result.Append(next.Name);
            }

            if (steps.Count != 0)
            {
                throw new InvalidOperationException();
            }

            return result.ToString();
        }

        private static Step MoveNext(IList<Step> steps)
        {
            for (var i = 0; i < steps.Count; i++)
            {
                var step = steps[i];
                if (step.DependsOn.Count == 0)
                {
                    steps.RemoveAt(i);

                    for (var j = 0; j < steps.Count; j++)
                    {
                        steps[j].DependsOn.Remove(step.Name);
                    }

                    return step;
                }
            }

            return null;
        }
    }
}
