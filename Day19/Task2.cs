using System.Collections.Generic;
using System.Linq;

namespace Day19
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var program = InputParser.Parse(input);
            var context = new OpCodeContext(new int[6]);
            context.Registers[0] = 1;

            for (var i = 0; i < 100; i++)
            {
                program.Execute(context);
            }

            var value = context.Registers.Max();
            var result = 0;
            for (var i = 1; i <= value; i++)
            {
                if (value % i == 0)
                {
                    result += i;
                }
            }

            return result;
        }
    }
}
