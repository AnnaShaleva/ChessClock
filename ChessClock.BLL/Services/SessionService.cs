using ChessClock.Kernel.Enums;
using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Repositories;
using ChessClock.Kernel.Services;

namespace ChessClock.BLL.Services
{
    internal class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        public ISession Add(ISession session)
        {
            return _sessionRepository.Add(session);
        }

        public ISession Get(string sessionId)
        {
            return _sessionRepository.Get(sessionId);
        }

        public ISession UpdateStatus(string sessionId, SessionStatus status)
        {
            var entity = _sessionRepository.Get(sessionId);

            if (entity.Status == status)
            {
                return entity;
            }
            else
            {
                var sessionToUpdate = entity.WithStatus(status);
                return _sessionRepository.Update(sessionToUpdate);
            }
        }

        public ISession UpdateCurrentPlayer(string sessionId, IPlayer player)
        {
            var entity = _sessionRepository.Get(sessionId);

            if(entity.CurrentPlayer == player)
            {
                return entity;
            }
            else
            {
                var sessionToUpdate = entity.WithCurrentPlayer(player);
                return _sessionRepository.Update(sessionToUpdate);
            }
            
        }
    }
}
