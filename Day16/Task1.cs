using System.Collections.Generic;

namespace Day16
{
    internal static class Task1
    {
        public static int Solve(IEnumerable<string> input)
        {
            var samples = InputParser.Parse(input).Samples;
            var opCodes = OpCodeFactory.GetAllOpCodes();

            var result = 0;
            foreach (var sample in samples)
            {
                var matchCounter = 0;
                foreach (var opCode in opCodes)
                {
                    var context = new OpCodeContext(sample.RegistersBefore);
                    opCode.A = sample.A;
                    opCode.B = sample.B;
                    opCode.C = sample.C;

                    opCode.Invoke(context);
                    if (context.IsMatch(sample.RegistersAfter))
                    {
                        matchCounter++;
                    }

                    if (matchCounter >= 3)
                    {
                        break;
                    }
                }

                if (matchCounter >= 3)
                {
                    result++;
                }
            }

            return result;
        }
    }
}
