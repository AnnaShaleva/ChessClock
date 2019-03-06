using ChessClock.Kernel.Invariance;
using System.Collections.Generic;

namespace ChessClock.Kernel.Services
{
    public interface IQueryService
    {   
        string Add(ISession session);
        string HandleNewSession(ISession session, IPlayer player);
        string HandleAddingPlayerSession(ISession currentSession, IEnumerable<string> tokens);
        string HandleRequestingNameSession(ISession currentSession, IPlayer player);
        string HandlePlayingSession(ISession currentSession);
    }
}
