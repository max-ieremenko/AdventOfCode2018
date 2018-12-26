using System.Collections.Generic;

namespace Day19
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var program = InputParser.Parse(input);
            var context = new OpCodeContext(new int[6]);

            while (program.Execute(context))
            {
            }

            return context.Registers[0];
        }
    }
}
