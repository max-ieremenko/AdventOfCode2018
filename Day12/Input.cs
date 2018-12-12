using System.Collections.Generic;

namespace Day12
{
    internal struct Input
    {
        public Input(bool[] initialState, IList<SpreadNote> notes)
        {
            InitialState = initialState;
            Notes = notes;
        }

        public bool[] InitialState { get; }

        public IList<SpreadNote> Notes { get; }
    }
}
