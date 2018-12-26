using System;
using System.Collections.Generic;
using System.Globalization;

namespace Day19
{
    internal static class InputParser
    {
        private const string IP = "#ip ";

        public static DeviceProgram Parse(IEnumerable<string> input)
        {
            var program = new DeviceProgram();
            foreach (var line in input)
            {
                if (line.StartsWith(IP))
                {
                    program.PointerRegister = ParseInt(line.Substring(IP.Length));
                }
                else
                {
                    var parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var opCode = OpCodeFactory.CreateByName(parts[0]);
                    program.Instructions.Add(opCode);
                    opCode.A = ParseInt(parts[1]);
                    opCode.B = ParseInt(parts[2]);
                    opCode.C = ParseInt(parts[3]);
                }
            }

            return program;
        }

        private static int ParseInt(string value)
        {
            return int.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}
