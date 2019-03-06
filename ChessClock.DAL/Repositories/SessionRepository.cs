using AutoMapper;
using ChessClock.DAL.Models;
using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ChessClock.Kernel.Entities;

namespace ChessClock.DAL.Repositories
{
    class SessionRepository : ISessionRepository
    {
        private readonly PostgresContext _context;
        private readonly IMapper _mapper;
        
        public SessionRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ISession Add(ISession session)
        {
            var entity = _mapper.Map<DalSession>(session);
            var result = _context.Add(entity);
            _context.SaveChanges(true);

            return _mapper.Map<Session>(result.Entity);
        }
        
        public ISession Get(string id)
        {
            var entity = _context.Sessions
                .Include(s => s.CurrentPlayer)
                .Include(s => s.Players)
                .FirstOrDefault(s => s.Id == id);

            return _mapper.Map<Session>(entity);
        }

        public ISession Update(ISession session)
        {
            var entity = _mapper.Map<DalSession>(session);
            var oldSession = _context.Sessions
                .FirstOrDefault(s => s.Id == session.Id);

            _context.Entry(oldSession).State = EntityState.Detached;

            entity.UserId = oldSession.UserId;

            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges(true);

            return Get(entity.Id);
        }
    }
}
