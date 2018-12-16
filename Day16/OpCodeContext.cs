namespace Day16
{
    internal struct OpCodeContext
    {
        public OpCodeContext(int[] registers)
        {
            Registers = (int[])registers.Clone();
        }

        public int[] Registers { get; }

        public bool IsMatch(int[] registers)
        {
            for (var i = 0; i < registers.Length; i++)
            {
                if (Registers[i] != registers[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}