using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChessClock.DAL.Models
{
    public class DalPlayer
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int NumberInQueue { get; set; }

        //ONE DalSession HAS MANY DalPlayers
        public string SessionId { get; set; }
        public DalSession Session { get; set; }

        //ONE DalPlayer HAS MANY DalMoves
        public IEnumerable<DalMove> Moves { get; set; }
    }
}
