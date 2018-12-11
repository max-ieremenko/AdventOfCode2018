using System;
using System.Collections.Generic;
using System.Globalization;

namespace Day11
{
    internal sealed class Grid
    {
        private readonly int[,] _cells;

        public Grid(int serialNumber)
        {
            SerialNumber = serialNumber;

            _cells = new int[Size, Size];

            for (var x = 0; x < Size; x++)
            {
                for (var y = 0; y < Size; y++)
                {
                    _cells[x, y] = CalculateCellPowerLevel(x + 1, y + 1);
                }
            }
        }

        public int SerialNumber { get; }

        public int Size => 300;

        public int GetCellPowerLevel(int x, int y)
        {
            return _cells[x - 1, y - 1];
        }

        public int GetAreaPowerLevel(int leftTopX, int leftTopY, int areaSize)
        {
            var result = 0;

            for (var x = leftTopX; x < leftTopX + areaSize; x++)
            {
                for (var y = leftTopY; y < leftTopY + areaSize; y++)
                {
                    result += GetCellPowerLevel(x, y);
                }
            }

            return result;
        }

        public KeyValuePair<int, int> GetCellMaxPowerLevel(int leftTopX, int leftTopY)
        {
            var maxSize = Math.Min(Size - leftTopX, Size - leftTopY);

            var maxPower = GetCellPowerLevel(leftTopX, leftTopY);
            var maxPowerSize = 1;

            var lastPower = maxPower;
            for (var size = 2; size <= maxSize; size++)
            {
                var power = lastPower;
                int x, y;

                x = leftTopX + size - 1;
                for (y = leftTopY; y < leftTopY + size; y++)
                {
                    power += GetCellPowerLevel(x, y);
                }

                y = leftTopY + size - 1;
                for (x = leftTopX; x < leftTopX + size - 1; x++)
                {
                    power += GetCellPowerLevel(x, y);
                }

                lastPower = power;
                if (power > maxPower)
                {
                    maxPower = power;
                    maxPowerSize = size;
                }
            }

            return new KeyValuePair<int, int>(maxPower, maxPowerSize);
        }

        private int CalculateCellPowerLevel(int x, int y)
        {
            long i = x + 10;
            i *= y;
            i += SerialNumber;
            i *= x + 10;

            var hundred = 0;
            if (i >= 100)
            {
                var text = i.ToString(CultureInfo.InvariantCulture);
                hundred = int.Parse(text.Substring(text.Length - 3, 1), CultureInfo.InvariantCulture);
            }

            return hundred - 5;
        }
    }
}
