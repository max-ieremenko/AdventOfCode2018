using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Day13
{
    internal sealed class Track
    {
        private readonly IDictionary<Point, Path> _pathByLocation;
        private readonly List<Cart> _carts;

        public Track()
        {
            _pathByLocation = new Dictionary<Point, Path>();
            _carts = new List<Cart>();
            Carts = new ReadOnlyCollection<Cart>(_carts);
        }

        public IList<Cart> Carts { get; }

        public void AddPath(Point location, Path direction)
        {
            _pathByLocation.Add(location, direction);
        }

        public void AddCart(Cart cart)
        {
            _carts.Add(cart);
        }

        public IList<Cart> Tick()
        {
            _carts.Sort(CompareCartsByMovingOrder);

            var collisions = new List<Cart>();

            for (var i = 0; i < _carts.Count; i++)
            {
                var cart = _carts[i];
                cart.Move(_pathByLocation[cart.Location]);

                var collisionsCount = collisions.Count;

                for (var j = 0; j < _carts.Count; j++)
                {
                    var testCart = _carts[j];
                    if (i != j && testCart.Location == cart.Location)
                    {
                        collisions.Add(testCart);
                        _carts.RemoveAt(j);
                        j--;
                        if (j < i)
                        {
                            i--;
                        }
                    }
                }

                if (collisionsCount != collisions.Count)
                {
                    collisions.Add(cart);
                    _carts.RemoveAt(i);
                    i--;
                }
            }

            return collisions;
        }

        public override string ToString()
        {
            var rightTop = _pathByLocation.Keys.First();
            foreach (var point in _pathByLocation.Keys)
            {
                rightTop = new Point(Math.Max(rightTop.X, point.X), Math.Max(rightTop.Y, point.Y));
            }

            var text = new StringBuilder((rightTop.X + 3) * (rightTop.Y + 1));

            for (var row = 0; row <= rightTop.Y; row++)
            {
                if (row > 0)
                {
                    text.AppendLine();
                }

                for (var column = 0; column <= rightTop.X; column++)
                {
                    var location = new Point(column, row);

                    if (!_pathByLocation.TryGetValue(location, out var direction))
                    {
                        direction = Path.None;
                    }

                    var carts = Carts
                        .Where(i => i.Location.X == column && i.Location.Y == row)
                        .Take(2)
                        .ToList();
                    if (carts.Count == 0)
                    {
                        text.Append((char)direction);
                    }
                    else if (carts.Count == 1)
                    {
                        text.Append((char)carts[0].Direction);
                    }
                    else
                    {
                        text.Append('X');
                    }
                }
            }

            return text.ToString();
        }

        private int CompareCartsByMovingOrder(Cart x, Cart y)
        {
            var c = x.Location.Y.CompareTo(y.Location.Y);
            if (c == 0)
            {
                c = x.Location.X.CompareTo(y.Location.X);
            }

            return c;
        }
    }
}