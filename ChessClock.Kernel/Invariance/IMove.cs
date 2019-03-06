using System;

namespace ChessClock.Kernel.Invariance
{
    public interface IMove
    {
        int PlayerId { get; }
        IPlayer Player { get; }
        DateTime Start { get; }
        DateTime End { get; }

        IMove WithEnd(DateTime time);
    }
}
