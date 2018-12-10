namespace Day08
{
    public static class Task1
    {
        public static int Solve(string input)
        {
            var root = TreeReader.Read(input);

            return root.SumMetadata();
        }
    }
}
