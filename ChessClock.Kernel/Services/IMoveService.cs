using ChessClock.Kernel.Invariance;
using System.Collections.Generic;

namespace ChessClock.Kernel.Services
{
    public interface IMoveService
    {
        IMove Add(IMove move);
        IEnumerable<IMove> GetAll(int playerId);
        IMove Update(IMove move);
    }
}
