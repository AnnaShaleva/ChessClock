using ChessClock.Kernel.Entities;
using ChessClock.Kernel.Enums;
using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ChessClock.BLL.Services
{
    internal class QueryService : IQueryService
    {
        private readonly ISessionService _sessionService;
        private readonly IPlayerService _playerService;
        private readonly IMoveService _moveService;

        public QueryService(ISessionService sessionService, IPlayerService playerService, IMoveService moveService)
        {
            _sessionService = sessionService;
            _playerService = playerService;
            _moveService = moveService;
        }

        public string Add(ISession session)
        {
            var entity = _sessionService.Get(session.Id);

            if(entity != null)
            {
                //TODO: define bihaviour in case when session already exists
            }
            else
            {
                _sessionService.Add(session);
            }

            return "Я помогу вам следить за временем в игре. Для начала, давайте познакомимся. Кто будет первым игроком?";
        }

        public string HandleNewSession(ISession session, IPlayer player)
        {           
            var currentPlayer = _playerService.Add(player);

            _sessionService.UpdateCurrentPlayer(session.Id, currentPlayer);

            _sessionService.UpdateStatus(session.Id, SessionStatus.AddingPlayer);

            return $"Добро пожаловать в игру, {player.Name}! Хотите добавить еще одного игрока?";
        }

        public string HandleAddingPlayerSession(ISession session, IEnumerable<string> tokens)
        {
            //TODO: more precise criteria for user's answer
            if (tokens.Any(t => t == "да"))
            {
                _sessionService.UpdateStatus(session.Id, SessionStatus.RequestingName);

                return "Как вас зовут?";
            }
            else
            {
                var currentPlayer = _playerService.GetCurrentPlayer(session.Id);

                _moveService.Add(new Move
                {
                    Player = (Player)currentPlayer,
                    PlayerId = currentPlayer.Id,
                    Start = DateTime.Now,
                });

                _sessionService.UpdateStatus(session.Id, SessionStatus.Playing);

                return $"Начнем игру! {currentPlayer.Name}, вы ходите первым.";
            }
        }

        public string HandleRequestingNameSession(ISession session, IPlayer player)
        {
            int playersCount = _playerService.GetAll(session.Id).Count();
            
            //TODO: null?
            _playerService.Add(player);

            _sessionService.UpdateStatus(session.Id, SessionStatus.AddingPlayer);

            return $"Добро пожаловать в игру, {player.Name}! Хотите добавить еще одного игрока?";
        }

        public string HandlePlayingSession(ISession session)
        {
            var currentPlayer = _playerService.GetCurrentPlayer(session.Id);
            IMove moveToUpdate = _moveService.GetAll(currentPlayer.Id).OrderBy(t => t.Start).LastOrDefault();

            moveToUpdate = moveToUpdate.WithEnd(DateTime.Now);

            _moveService.Update(moveToUpdate);

            currentPlayer = _playerService.UpdateCurrentPlayer(session.Id);

            //TODO: refactor this 
            _moveService.Add(new Move
            {
                Player = (Player)currentPlayer,
                PlayerId = currentPlayer.Id,
                Start = DateTime.Now,
            });

            return $"Отлично. {currentPlayer.Name}, теперь ваш ход.";
        }
    }
}
