namespace Day12
{
    internal sealed class History
    {
        private int _lastPlantsCountRepeated;

        public int PlantsCount { get; set; }

        public bool Balanced(int plantsCount)
        {
            if (plantsCount == PlantsCount)
            {
                _lastPlantsCountRepeated++;
                if (_lastPlantsCountRepeated == 10)
                {
                    return true;
                }
            }
            else
            {
                PlantsCount = plantsCount;
                _lastPlantsCountRepeated = 1;
            }

            return false;
        }
    }
}
