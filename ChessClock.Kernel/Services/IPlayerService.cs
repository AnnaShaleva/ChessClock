using ChessClock.Kernel.Invariance;
using System.Collections.Generic;

namespace ChessClock.Kernel.Services
{
    public interface IPlayerService
    {
        IPlayer Add(IPlayer player);
        IEnumerable<IPlayer> GetAll(string sessionId);
        IPlayer GetCurrentPlayer(string sessionId);
        IPlayer UpdateCurrentPlayer(string sessionId);
    }
}
