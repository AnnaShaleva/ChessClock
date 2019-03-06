using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ChessClock.DAL.Models;
using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Repositories;
using System.Collections.Generic;
using System.Linq;
using ChessClock.Kernel.Entities;

namespace ChessClock.DAL.Repositories
{
    class PlayerRepository : IPlayerRepository
    {
        private readonly PostgresContext _context;
        private readonly IMapper _mapper;

        public PlayerRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IPlayer Add(IPlayer player)
        {
            var entity = _mapper.Map<DalPlayer>(player);
            var result = _context.Add(entity);

            _context.SaveChanges(true);

            return _mapper.Map<Player>(result.Entity);
        }

        public IEnumerable<IPlayer> GetAll(string sessionId)
        {
            var entity = _context.Players
                .Include(p => p.Moves)
                .Include(p => p.Session)
                //.AsNoTracking()
                .Where(p => p.SessionId == sessionId)
                .ToList();

            //TODO: null exception handling
            return entity.Select(p => _mapper.Map<Player>(p));
        }
    }
}
