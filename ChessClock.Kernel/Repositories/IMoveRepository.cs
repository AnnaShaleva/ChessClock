using ChessClock.Kernel.Invariance;
using System.Collections.Generic;

namespace ChessClock.Kernel.Repositories
{
    public interface IMoveRepository
    {
        IMove Add(IMove move);
        IMove Get(int id);
        IEnumerable<IMove> GetAll(int playerId);
        IMove Update(IMove move);
    }
}
