using ChessClock.Kernel.Invariance;

namespace ChessClock.Kernel.Repositories
{
    public interface ISessionRepository
    {
        ISession Add(ISession session);
        ISession Get(string id);
        ISession Update(ISession session);
    }
}
