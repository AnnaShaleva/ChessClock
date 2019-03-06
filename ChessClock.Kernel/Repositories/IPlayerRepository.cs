using ChessClock.Kernel.Invariance;
using System.Collections.Generic;

namespace ChessClock.Kernel.Repositories
{
    public interface IPlayerRepository
    {
        IPlayer Add(IPlayer player);
        IEnumerable<IPlayer> GetAll(string sessionId);
    }
}
