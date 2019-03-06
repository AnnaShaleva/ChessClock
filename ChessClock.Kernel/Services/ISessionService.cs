using ChessClock.Kernel.Enums;
using ChessClock.Kernel.Invariance;

namespace ChessClock.Kernel.Services
{
    public interface ISessionService
    {
        ISession Get(string id);
        ISession Add(ISession session);
        ISession UpdateStatus(string sessionId, SessionStatus status);
        ISession UpdateCurrentPlayer(string sessionId, IPlayer player);
    }
}
