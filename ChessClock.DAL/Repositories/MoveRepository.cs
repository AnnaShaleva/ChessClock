using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ChessClock.DAL.Models;
using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using ChessClock.Kernel.Entities;

namespace ChessClock.DAL.Repositories
{
    public class MoveRepository : IMoveRepository
    {
        private readonly PostgresContext _context;
        private readonly IMapper _mapper;
        
        public MoveRepository(PostgresContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IMove Add(IMove move)
        {
            var entity = _mapper.Map<DalMove>(move);
            var result = _context.Add(entity);
            _context.SaveChanges(true);

            //TODO exception handling
            return _mapper.Map<Move>(result.Entity);
        }

        public IMove Get(int id)
        {
            var entity = _context.Moves
                .Include(m => m.Player)
                .AsNoTracking()
                .FirstOrDefault(m => m.Id == id);

            return _mapper.Map<Move>(entity);
        }

        public IEnumerable<IMove> GetAll(int playerId)
        {
            var entity = _context.Moves
                .Include(m => m.Player)
                .AsNoTracking()
                .Where(m => m.PlayerId == playerId)
                .ToList();

            return entity.Select(m => _mapper.Map<Move>(m));
        }

        public IMove Update(IMove move)
        {
            var entity = _mapper.Map<DalMove>(move);
            var oldEntity = _context.Moves
                .FirstOrDefault(m => m.Id == entity.Id);
            if (oldEntity != null)
            {
                _context.Entry(oldEntity).State = EntityState.Detached;

                entity.Id = oldEntity.Id;
                entity.PlayerId = oldEntity.PlayerId;

                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges(true);

                return Get(entity.Id);            
            }

            //TODO: implement custom exception
            throw new ArgumentNullException();
        }
    }
}
