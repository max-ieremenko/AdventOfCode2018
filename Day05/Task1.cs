using System.Text;

namespace Day05
{
    public static class Task1
    {
        public static int Solve(string input)
        {
            var test = new StringBuilder(input.Trim());
            React(test);

            return test.Length;
        }

        internal static bool AreOpposite(char x, char y)
        {
            if (char.IsUpper(x))
            {
                if (!char.IsLower(y))
                {
                    return false;
                }

                return x.Equals(char.ToUpperInvariant(y));
            }

            if (!char.IsUpper(y))
            {
                return false;
            }

            return x.Equals(char.ToLowerInvariant(y));
        }

        internal static void React(StringBuilder input)
        {
            var length = input.Length;

            for (var i = 0; i < input.Length - 1; i++)
            {
                if (AreOpposite(input[i], input[i + 1]))
                {
                    input.Remove(i, 2);
                    i--;
                }
            }

            if (input.Length != length)
            {
                React(input);
            }
        }
    }
}
