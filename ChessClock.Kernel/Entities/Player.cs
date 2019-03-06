using ChessClock.Kernel.Invariance;
using System.Collections.Generic;

namespace ChessClock.Kernel.Entities
{
    public class Player : IPlayer
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        //TODO: change the name of the property
        public int NumberInQueue { get; set; }

        public string SessionId { get; set; }

        public IEnumerable<Move> Moves { get; set; }
    }
}
