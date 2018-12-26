using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Day18
{
    internal sealed class Map
    {
        private Area[,] _acres;

        public Map(Area[,] acres)
        {
            _acres = acres;
        }

        public int GetResourceValue()
        {
            var wooded = 0;
            var lumberyards = 0;

            for (var y = 0; y < _acres.GetLength(1); y++)
            {
                for (var x = 0; x < _acres.GetLength(0); x++)
                {
                    switch (_acres[x, y])
                    {
                        case Area.Tree:
                            wooded++;
                            break;

                        case Area.Lumberyard:
                            lumberyards++;
                            break;
                    }
                }
            }

            return wooded * lumberyards;
        }

        public void NextMinute()
        {
            var newAcres = (Area[,])_acres.Clone();

            for (var y = 0; y < _acres.GetLength(1); y++)
            {
                for (var x = 0; x < _acres.GetLength(0); x++)
                {
                    var current = _acres[x, y];

                    switch (current)
                    {
                        case Area.Ground:
                            if (GetNeighbors(x, y).Count(i => i == Area.Tree) >= 3)
                            {
                                current = Area.Tree;
                            }

                            break;
                        case Area.Tree:
                            if (GetNeighbors(x, y).Count(i => i == Area.Lumberyard) >= 3)
                            {
                                current = Area.Lumberyard;
                            }

                            break;
                        case Area.Lumberyard:
                            if (GetNeighbors(x, y).Any(i => i == Area.Lumberyard) && GetNeighbors(x, y).Any(i => i == Area.Tree))
                            {
                                current = Area.Lumberyard;
                            }
                            else
                            {
                                current = Area.Ground;
                            }

                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    newAcres[x, y] = current;
                }
            }

            _acres = newAcres;
        }

        public override string ToString()
        {
            var text = new StringBuilder();

            for (var y = 0; y < _acres.GetLength(1); y++)
            {
                if (text.Length > 0)
                {
                    text.AppendLine();
                }

                for (var x = 0; x < _acres.GetLength(0); x++)
                {
                    text.Append((char)_acres[x, y]);
                }
            }

            return text.ToString();
        }

        private IEnumerable<Area> GetNeighbors(int x, int y)
        {
            var points = new[]
            {
                new Point(x - 1, y - 1),
                new Point(x - 1, y),
                new Point(x - 1, y + 1),

                new Point(x + 1, y - 1),
                new Point(x + 1, y),
                new Point(x + 1, y + 1),

                new Point(x, y - 1),
                new Point(x, y + 1)
            };

            foreach (var point in points)
            {
                if (point.X >= 0 && point.Y >= 0 && point.X < _acres.GetLength(0) && point.Y < _acres.GetLength(1))
                {
                    yield return _acres[point.X, point.Y];
                }
            }
        }
    }
}