using System.Collections.Generic;

namespace Day19
{
    internal sealed class DeviceProgram
    {
        public int PointerRegister { get; set; }

        public IList<OpCodeBase> Instructions { get; } = new List<OpCodeBase>();

        public bool Execute(OpCodeContext context)
        {
            var pointer = context.Registers[PointerRegister];
            if (pointer < 0 || pointer >= Instructions.Count)
            {
                return false;
            }

            ////var state = context.ToString();
            var instruction = Instructions[pointer];
            instruction.Invoke(context);

            ////Console.WriteLine("{0} {1} [{2}] => [{3}]", pointer, instruction, state, context);

            pointer = context.Registers[PointerRegister] + 1;
            context.Registers[PointerRegister] = pointer;

            return true;
        }
    }
}