using System;
using System.Drawing;

namespace Day22
{
    internal static class Task1
    {
        public static int Solve(int depth, Point target)
        {
            var caves = new CaveSystem(depth, target);

            var totalRiskLevel = 0;
            for (var y = 0; y <= target.Y; y++)
            {
                for (var x = 0; x <= target.X; x++)
                {
                    int caseRiskLevel;
                    switch (caves.GetCaveType(new Point(x, y)))
                    {
                        case RegionType.Rocky:
                            caseRiskLevel = 0;
                            break;
                        case RegionType.Narrow:
                            caseRiskLevel = 2;
                            break;
                        case RegionType.Wet:
                            caseRiskLevel = 1;
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    totalRiskLevel += caseRiskLevel;
                }
            }

            return totalRiskLevel;
        }
    }
}
