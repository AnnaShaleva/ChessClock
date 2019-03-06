using ChessClock.Kernel.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChessClock.DAL.Models
{
    public class DalSession
    {
        [Key]
        public string Id { get; set; }

        public string UserId { get; set; }

        public SessionStatus Status { get; set; }

        //ONE DalSession HAS ONE DalPlayer as CurrentPlayer
        public int? CurrentPlayerId { get; set; }
        public DalPlayer CurrentPlayer { get; set; }

        //ONE DalSession HAS MANY DalPlayers
        public IEnumerable<DalPlayer> Players { get; set; }

    }
}
