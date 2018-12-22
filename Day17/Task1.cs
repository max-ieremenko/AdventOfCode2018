using System.Collections.Generic;

namespace Day17
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var map = InputParser.Parse(input);

            var spring = new Spring(map);
            spring.Fill();

            return map.GetCellsNumberWithWater();
        }
    }
}
