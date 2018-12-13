using System;
using System.Diagnostics;
using System.Drawing;

namespace Day13
{
    [DebuggerDisplay("{Location.X},{Location.Y} {Direction}")]
    internal sealed class Cart
    {
        private CartTurnDirection _nextTurn;

        public Cart(Point location, CartDirection direction)
        {
            Location = location;
            Direction = direction;
            _nextTurn = CartTurnDirection.Left;
        }

        public Point Location { get; private set; }

        public CartDirection Direction { get; private set; }

        public void Move(Path path)
        {
            switch (Direction)
            {
                case CartDirection.Right:
                    MoveRight(path);
                    break;
                case CartDirection.Left:
                    MoveLeft(path);
                    break;
                case CartDirection.Down:
                    MoveDown(path);
                    break;
                case CartDirection.Up:
                    MoveUp(path);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveRight(Path path)
        {
            switch (path)
            {
                // ->-
                case Path.Horizontal:
                    Location = new Point(Location.X + 1, Location.Y);
                    break;

                // - >\
                //   |
                case Path.SlashCurve:
                    Location = new Point(Location.X, Location.Y + 1);
                    Direction = CartDirection.Down;
                    break;

                ////  |
                // - >/
                case Path.BackSlashCurve:
                    Location = new Point(Location.X, Location.Y - 1);
                    Direction = CartDirection.Up;
                    break;

                // - >+
                case Path.Intersection:
                    switch (_nextTurn)
                    {
                        case CartTurnDirection.Right:
                            Location = new Point(Location.X, Location.Y + 1);
                            Direction = CartDirection.Down;
                            break;
                        case CartTurnDirection.Left:
                            Location = new Point(Location.X, Location.Y - 1);
                            Direction = CartDirection.Up;
                            break;
                        case CartTurnDirection.Straight:
                            Location = new Point(Location.X + 1, Location.Y);
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    SetNextTurn();
                    break;

                case Path.Vertical:
                default:
                    throw new NotSupportedException();
            }
        }

        private void MoveLeft(Path path)
        {
            switch (path)
            {
                // -<-
                case Path.Horizontal:
                    Location = new Point(Location.X - 1, Location.Y);
                    break;

                // /< -
                // |
                case Path.BackSlashCurve:
                    Location = new Point(Location.X, Location.Y + 1);
                    Direction = CartDirection.Down;
                    break;

                // |
                // \< -
                case Path.SlashCurve:
                    Location = new Point(Location.X, Location.Y - 1);
                    Direction = CartDirection.Up;
                    break;

                // +< -
                case Path.Intersection:
                    switch (_nextTurn)
                    {
                        case CartTurnDirection.Right:
                            Location = new Point(Location.X, Location.Y - 1);
                            Direction = CartDirection.Up;
                            break;
                        case CartTurnDirection.Left:
                            Location = new Point(Location.X, Location.Y + 1);
                            Direction = CartDirection.Down;
                            break;
                        case CartTurnDirection.Straight:
                            Location = new Point(Location.X - 1, Location.Y);
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    SetNextTurn();
                    break;

                case Path.Vertical:
                default:
                    throw new NotSupportedException();
            }
        }

        private void MoveDown(Path path)
        {
            switch (path)
            {
                // |
                // v
                // |
                case Path.Vertical:
                    Location = new Point(Location.X, Location.Y + 1);
                    break;

                // |
                // v\
                case Path.SlashCurve:
                    Location = new Point(Location.X + 1, Location.Y);
                    Direction = CartDirection.Right;
                    break;

                //// |
                //  v/
                // -
                case Path.BackSlashCurve:
                    Location = new Point(Location.X - 1, Location.Y);
                    Direction = CartDirection.Left;
                    break;

                // |
                // v
                // +
                case Path.Intersection:
                    switch (_nextTurn)
                    {
                        case CartTurnDirection.Right:
                            Location = new Point(Location.X - 1, Location.Y);
                            Direction = CartDirection.Left;
                            break;
                        case CartTurnDirection.Left:
                            Location = new Point(Location.X + 1, Location.Y);
                            Direction = CartDirection.Right;
                            break;
                        case CartTurnDirection.Straight:
                            Location = new Point(Location.X, Location.Y + 1);
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    SetNextTurn();
                    break;

                case Path.Horizontal:
                default:
                    throw new NotSupportedException();
            }
        }

        private void MoveUp(Path path)
        {
            switch (path)
            {
                // |
                // ^
                // |
                case Path.Vertical:
                    Location = new Point(Location.X, Location.Y - 1);
                    break;

                // -^\
                //  |
                case Path.SlashCurve:
                    Location = new Point(Location.X - 1, Location.Y);
                    Direction = CartDirection.Left;
                    break;

                // ^/
                // |
                case Path.BackSlashCurve:
                    Location = new Point(Location.X + 1, Location.Y);
                    Direction = CartDirection.Right;
                    break;

                // +
                // ^
                // |
                case Path.Intersection:
                    switch (_nextTurn)
                    {
                        case CartTurnDirection.Right:
                            Location = new Point(Location.X + 1, Location.Y);
                            Direction = CartDirection.Right;
                            break;
                        case CartTurnDirection.Left:
                            Location = new Point(Location.X - 1, Location.Y);
                            Direction = CartDirection.Left;
                            break;
                        case CartTurnDirection.Straight:
                            Location = new Point(Location.X, Location.Y - 1);
                            break;
                        default:
                            throw new NotSupportedException();
                    }

                    SetNextTurn();
                    break;

                case Path.Horizontal:
                default:
                    throw new NotSupportedException();
            }
        }

        private void SetNextTurn()
        {
            _nextTurn = (CartTurnDirection)((int)_nextTurn + 1);
            if (_nextTurn > CartTurnDirection.Right)
            {
                _nextTurn = CartTurnDirection.Left;
            }
        }
    }
}