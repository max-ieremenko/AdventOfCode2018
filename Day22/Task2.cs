using System.Drawing;

namespace Day22
{
    internal static class Task2
    {
        public static int Solve(int depth, Point target)
        {
            var caves = new CaveSystem(depth, target);

            var path = new PathResolver(caves).FindPath(new Point(0, 0), Tool.Torch);

            return path.Value;
        }
    }
}
