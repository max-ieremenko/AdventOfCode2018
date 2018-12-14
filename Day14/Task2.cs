using System.Globalization;

namespace Day14
{
    internal static class Task2
    {
        public static int Solve(string input)
        {
            var scoreboard = new Scoreboard(int.Parse(input, CultureInfo.InvariantCulture));
            var sequence = new ScoreSequence(input);

            int offset;
            while ((offset = sequence.Matches(scoreboard.Scores)) < 0)
            {
                scoreboard.CreateNewRecipe();
            }

            return offset;
        }
    }
}
