using System.Collections.Generic;
using System.Drawing;

namespace Day10
{
    internal sealed class Task
    {
        private Sky _sky;

        public int WaitTime { get; private set; }

        public void Solve(IEnumerable<string> input)
        {
            _sky = new Sky(input);

            var size = _sky.GetRectangle().Size;
            var area = Area(size);

            while (true)
            {
                _sky.MoveForward();

                var nextSize = _sky.GetRectangle().Size;
                var nextArea = Area(nextSize);

                if (nextArea > area)
                {
                    _sky.MoveBack();
                    break;
                }

                WaitTime++;
                area = nextArea;
            }
        }

        public string GetMessage() => _sky.ToString();

        private static long Area(Size size)
        {
            return (long)size.Width * size.Height;
        }
    }
}
