using ChessClock.Kernel.Invariance;
using ChessClock.Kernel.Repositories;
using ChessClock.Kernel.Services;
using System.Collections.Generic;

namespace ChessClock.BLL.Services
{
    public class MoveService : IMoveService
    {
        private readonly IMoveRepository _moveRepository;

        public MoveService(IMoveRepository moveRepository)
        {
            _moveRepository = moveRepository;
        }
        public IMove Add(IMove move)
        {
            return _moveRepository.Add(move);
        }

        public IEnumerable<IMove> GetAll(int playerId)
        {
            return _moveRepository.GetAll(playerId);
        }

        public IMove Update(IMove move)
        {
            return _moveRepository.Update(move);
        }
    }
}
