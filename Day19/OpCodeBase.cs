using System.Globalization;

namespace Day19
{
    internal abstract class OpCodeBase
    {
        public int A { get; set; }

        public int B { get; set; }

        public int C { get; set; }

        public abstract void Invoke(OpCodeContext context);

        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0} {1} {2} {3}",
                GetType().Name,
                A,
                B,
                C);
        }
    }
}