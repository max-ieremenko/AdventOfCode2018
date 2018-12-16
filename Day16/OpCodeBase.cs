namespace Day16
{
    internal abstract class OpCodeBase
    {
        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public abstract void Invoke(OpCodeContext context);
    }
}