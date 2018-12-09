using System.Collections.Generic;
using System.Linq;

namespace Day9
{
    public static class Task
    {
        public static long Solve(int playersCount, int lastMarbleNumber)
        {
            var pointer = new Marble(0);
            pointer.Next = pointer;
            pointer.Previous = pointer;

            var player = 1;
            var scoresByPlayer = new Dictionary<int, long>();

            for (var i = 1; i <= lastMarbleNumber; i++)
            {
                if (i % 23 == 0)
                {
                    scoresByPlayer.TryGetValue(player, out var scores);
                    scores += i;

                    var moveTo = pointer.Previous.Previous.Previous.Previous.Previous.Previous.Previous;
                    scores += moveTo.Number;

                    moveTo.Previous.Next = moveTo.Next;
                    moveTo.Next.Previous = moveTo.Previous;

                    pointer = moveTo.Next;

                    scoresByPlayer[player] = scores;
                }
                else
                {
                    var marble = new Marble(i);
                    var insertAfter = pointer.Next;

                    marble.Previous = insertAfter;
                    marble.Next = insertAfter.Next;

                    insertAfter.Next.Previous = marble;
                    insertAfter.Next = marble;

                    pointer = marble;
                }

                player++;
                if (player > playersCount)
                {
                    player = 1;
                }
            }

            return scoresByPlayer.Values.Max();
        }
    }
}
