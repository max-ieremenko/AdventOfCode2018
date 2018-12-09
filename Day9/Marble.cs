using System.Diagnostics;

namespace Day9
{
    [DebuggerDisplay("{Number}")]
    internal sealed class Marble
    {
        public Marble(int number)
        {
            Number = number;
        }

        public int Number { get; }

        public Marble Next { get; set; }

        public Marble Previous { get; set; }
    }
}
