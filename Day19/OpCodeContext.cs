namespace Day19
{
    internal struct OpCodeContext
    {
        public OpCodeContext(int[] registers)
        {
            Registers = (int[])registers.Clone();
        }

        public int[] Registers { get; }

        public override string ToString()
        {
            return string.Join(", ", Registers);
        }
    }
}