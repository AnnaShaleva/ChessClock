using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using ChessClock.Kernel.Entities;
using ChessClock.Kernel.Services;
using AutoMapper;
using ChessClock.Kernel.Enums;
using ChessClock.Models;

namespace ChessClock.Controllers
{
    [Route("api/Queries")]
    [ApiController]
    public class QueriesController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IQueryService _queryService;
        private readonly ISessionService _sessionService;
        private readonly IPlayerService _playerService;
        private readonly IMapper _mapper;

        public QueriesController(IConfiguration configuration, IQueryService queryService, ISessionService sessionService, IPlayerService playerService, IMapper mapper)
        {
            _configuration = configuration;
            _queryService = queryService;
            _sessionService = sessionService;
            _playerService = playerService;
            _mapper = mapper;
        }

        //POST: api/Queries
        [HttpPost]
        [Produces("application/json")]
        public IActionResult Create([FromBody] JObject jsonQuery)
        {
            if (jsonQuery == null)
            {
                return BadRequest();
            }
            var text = "";

            var query = jsonQuery.ToObject<ApiInputQuery>();
            try
            {
                GetText(query, out text);
            }
            //TODO: bad practice, add custom exceptions
            catch (Exception e)
            {
                //TODO: add logger
                text = "Пожалуйста, повторите";
            }            

            bool end_session = false;
            var session_id = query.Session.SessionId;
            var message_id = query.Session.MessageId;
            var user_id = query.Session.UserId;
            string version = query.Version;

            var toReturn = JObject.FromObject(new
            {
                response = new
                {
                    text,
                    end_session
                },
                session = new
                {
                    session_id,
                    message_id,
                    user_id
                },
                version
            });

            return new JsonResult(toReturn);
        }

        private void GetText(ApiInputQuery query, out string text)
        {
            if (query.Session.New)
            {
                text = _queryService.Add(_mapper.Map<Session>(query.Session));
            }
            else
            {
                var currentSession = _sessionService.Get(query.Session.SessionId);
                int playersCount = _playerService.GetAll(currentSession.Id).Count();

                var player = query.Request.NLU.Entities
                    .Where(t => t["type"].ToObject<string>() == "YANDEX.FIO")
                    .Select(t => new Player
                    {
                        Name = t["value"]["first_name"].ToObject<string>(),
                        SessionId = currentSession.Id,
                        NumberInQueue = playersCount,
                    })
                    .FirstOrDefault();

                var tokens = query.Request.NLU.Tokens;

                switch (currentSession.Status)
                {
                    case SessionStatus.New:

                        text = _queryService.HandleNewSession(currentSession, player);

                        break;

                    case SessionStatus.AddingPlayer:

                        text = _queryService.HandleAddingPlayerSession(currentSession, tokens);

                        break;

                    case SessionStatus.RequestingName:

                        text = _queryService.HandleRequestingNameSession(currentSession, player);

                        break;

                    case SessionStatus.Playing:

                        text = _queryService.HandlePlayingSession(currentSession);

                        break;

                    default:

                        //TODO: refactor this, add exception handling
                        //Important: unreachable code
                        text = "Повторите, пожалуйста";

                        break;
                }
            }
        }
    }
}