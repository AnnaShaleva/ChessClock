using System;
using System.ComponentModel.DataAnnotations;

namespace ChessClock.DAL.Models
{
    public class DalMove
    {
        [Key]
        public int Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        //ONE DalPlayer HAS MANY DalMoves
        public int PlayerId { get; set; }
        public DalPlayer Player { get; set; }
    }
}
