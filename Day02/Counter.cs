namespace Day02
{
    internal struct Counter
    {
        public Counter(bool two, bool three)
        {
            Two = two;
            Three = three;
        }

        public bool Two { get; }

        public bool Three { get; }
    }
}
