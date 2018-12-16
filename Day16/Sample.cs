namespace Day16
{
    internal struct Sample
    {
        public Sample(int[] registersBefore, int[] registersAfter, int[] instruction)
        {
            RegistersBefore = registersBefore;
            RegistersAfter = registersAfter;

            OpCode = instruction[0];
            A = instruction[1];
            B = instruction[2];
            C = instruction[3];
        }

        public int[] RegistersBefore { get; }

        public int[] RegistersAfter { get; }

        public int OpCode { get; }

        public int A { get; }

        public int B { get; }

        public int C { get; }
    }
}