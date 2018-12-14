using System.Text;

namespace Day14
{
    internal static class Task1
    {
        private const int ScoresOfRecipes = 10;

        public static string Solve(int input)
        {
            var expectedRecipesCount = input + ScoresOfRecipes;
            var scoreboard = new Scoreboard(expectedRecipesCount);

            while (scoreboard.Scores.Count < expectedRecipesCount)
            {
                scoreboard.CreateNewRecipe();
            }

            var result = new StringBuilder(ScoresOfRecipes);
            for (var i = input; i < input + ScoresOfRecipes; i++)
            {
                result.Append(scoreboard.Scores[i]);
            }

            return result.ToString();
        }
    }
}
