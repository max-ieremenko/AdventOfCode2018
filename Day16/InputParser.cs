using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Day16
{
    internal static class InputParser
    {
        public static Input Parse(IEnumerable<string> input)
        {
            const string Before = "Before: ";
            const string After = "After: ";

            var samples = new List<Sample>();
            var testProgram = new List<int[]>();

            int[] registersBefore = null;
            int[] instruction = null;
            var testProgramBegin = false;

            foreach (var line in input)
            {
                if (testProgramBegin)
                {
                    if (line.Length > 0)
                    {
                        testProgram.Add(ParseArray(line));
                    }
                }
                else
                {
                    if (line.StartsWith(Before))
                    {
                        registersBefore = ParseArray(line.Substring(Before.Length));
                    }
                    else if (line.StartsWith(After))
                    {
                        var registersAfter = ParseArray(line.Substring(After.Length));

                        samples.Add(new Sample(registersBefore, registersAfter, instruction));
                        registersBefore = null;
                        instruction = null;
                    }
                    else if (line.Length > 0)
                    {
                        if (registersBefore == null)
                        {
                            testProgramBegin = true;
                        }
                        else
                        {
                            instruction = ParseArray(line);
                        }
                    }
                }
            }

            return new Input(samples, testProgram);
        }

        private static int[] ParseArray(string input)
        {
            input = input.Trim(' ', '[', ']');
            return input
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(i => int.Parse(i, CultureInfo.InvariantCulture))
                .ToArray();
        }
    }
}
