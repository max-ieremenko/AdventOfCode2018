namespace Day15
{
    internal struct RoundResult
    {
        public RoundResult(bool isFullRound, bool combatIsFinished)
        {
            IsFullRound = isFullRound;
            CombatIsFinished = combatIsFinished;
        }

        public bool IsFullRound { get; }

        public bool CombatIsFinished { get; }
    }
}
