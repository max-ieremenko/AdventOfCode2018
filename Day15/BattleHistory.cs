namespace Day15
{
    internal sealed class BattleHistory
    {
        public int TotalRounds { get; private set; }

        public int FullRounds { get; private set; }

        public void NextRound(bool isFullRound)
        {
            TotalRounds++;

            if (isFullRound)
            {
                FullRounds = TotalRounds;
            }
        }
    }
}
