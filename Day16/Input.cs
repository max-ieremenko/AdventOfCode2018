using System.Collections.Generic;

namespace Day16
{
    internal struct Input
    {
        public Input(IList<Sample> samples, IList<int[]> program)
        {
            Samples = samples;
            Program = program;
        }

        public IList<Sample> Samples { get; }

        public IList<int[]> Program { get; }
    }
}
