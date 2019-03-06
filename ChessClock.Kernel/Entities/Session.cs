using ChessClock.Kernel.Enums;
using ChessClock.Kernel.Invariance;

namespace ChessClock.Kernel.Entities
{
    public class Session : ISession
    {
        public string Id { get; set; }

        public string UserId { get; set; }

        public SessionStatus Status { get; set; }

        public Player CurrentPlayer { get; set; }
        IPlayer ISession.CurrentPlayer => CurrentPlayer;

        public ISession WithStatus(SessionStatus status)
        {
            var clone = (Session)MemberwiseClone();
            clone.Status = status;
            return clone;
        }

        public ISession WithCurrentPlayer(IPlayer player)
        {
            var clone = (Session)MemberwiseClone();
            clone.CurrentPlayer = (Player)player;
            return clone;

        }
    }
}
