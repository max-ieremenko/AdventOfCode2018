using System.Collections.Generic;

namespace Day12
{
    internal static class Task
    {
        public static long Solve(IEnumerable<string> input, long generationsCount)
        {
            var tunnel = InputParser.Parse(input);
            var history = new History();

            for (var i = 0; i < generationsCount; i++)
            {
                tunnel.NextGeneration();

                if (history.Balanced(tunnel.GetPlantsCount()))
                {
                    var sum = tunnel.SumPlantNumbers();
                    sum += history.PlantsCount * (generationsCount - i - 1);
                    return sum;
                }
            }

            return tunnel.SumPlantNumbers();
        }
    }
}
