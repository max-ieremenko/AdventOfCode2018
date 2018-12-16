using System;
using System.Collections.Generic;
using System.Linq;

namespace Day16
{
    internal static class Task2
    {
        public static int Solve(IEnumerable<string> input)
        {
            var task = InputParser.Parse(input);
            var factory = ResolveOpCodeFactory(BuildPossibilities(task.Samples));

            var context = new OpCodeContext(new int[4]);
            foreach (var line in task.Program)
            {
                var opCode = factory(line[0]);
                opCode.A = line[1];
                opCode.B = line[2];
                opCode.C = line[3];
                opCode.Invoke(context);
            }

            return context.Registers[0];
        }

        private static Func<int, OpCodeBase> ResolveOpCodeFactory(IDictionary<int, ICollection<Type>> possibilities)
        {
            var opCodeById = new Dictionary<int, Type>(possibilities.Count);
            while (possibilities.Count > 0)
            {
                foreach (var id in possibilities.Keys.ToArray())
                {
                    var candidates = possibilities[id];
                    if (candidates.Count == 1)
                    {
                        var type = candidates.First();
                        opCodeById.Add(id, type);
                        possibilities.Remove(id);

                        foreach (var entry in possibilities.Values)
                        {
                            entry.Remove(type);
                        }
                    }
                }
            }

            return id =>
            {
                var type = opCodeById[id];
                return (OpCodeBase)Activator.CreateInstance(type);
            };
        }

        private static IDictionary<int, ICollection<Type>> BuildPossibilities(IEnumerable<Sample> samples)
        {
            var opCodes = OpCodeFactory.GetAllOpCodes();
            var result = new Dictionary<int, ICollection<Type>>(opCodes.Count);

            foreach (var sample in samples)
            {
                foreach (var opCode in opCodes)
                {
                    var context = new OpCodeContext(sample.RegistersBefore);
                    opCode.A = sample.A;
                    opCode.B = sample.B;
                    opCode.C = sample.C;

                    opCode.Invoke(context);
                    if (context.IsMatch(sample.RegistersAfter))
                    {
                        if (!result.TryGetValue(sample.OpCode, out var types))
                        {
                            types = new HashSet<Type>();
                            result.Add(sample.OpCode, types);
                        }

                        types.Add(opCode.GetType());
                    }
                }
            }

            return result;
        }
    }
}
