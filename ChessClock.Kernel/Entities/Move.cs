using ChessClock.Kernel.Invariance;
using System;

namespace ChessClock.Kernel.Entities
{
    public class Move : IMove
    {
        public int Id { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; }
        IPlayer IMove.Player => Player;        

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public IMove WithEnd(DateTime time)
        {
            var clone = (Move)MemberwiseClone();
            clone.End = time;
            return clone;
        }
    }
}
