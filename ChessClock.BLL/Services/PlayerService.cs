using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Repositories;
using ChessClock.Kernel.Services;
using System.Collections.Generic;
using System.Linq;

namespace ChessClock.BLL.Services
{
    class PlayerService : IPlayerService
    {
        private readonly ISessionService _sessionService;
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(ISessionService sessionService, IPlayerRepository playerRepository)
        {
            _sessionService = sessionService;
            _playerRepository = playerRepository;
        }

        public IPlayer Add(IPlayer player)
        {
            return _playerRepository.Add(player);
        }

        public IEnumerable<IPlayer> GetAll(string sessionId)
        {
            return _playerRepository.GetAll(sessionId);
        }

        public IPlayer GetCurrentPlayer(string sessionId)
        {
            return _sessionService.Get(sessionId).CurrentPlayer;
        }

        public IPlayer UpdateCurrentPlayer(string sessionId)
        {
            var playersCount = GetAll(sessionId).Count();

            var numberInQueue = (GetCurrentPlayer(sessionId).NumberInQueue + 1) % playersCount;

            var player = GetAll(sessionId).Where(t => t.NumberInQueue == numberInQueue).FirstOrDefault();

            return _sessionService.UpdateCurrentPlayer(sessionId, player).CurrentPlayer;
        }
    }
}
