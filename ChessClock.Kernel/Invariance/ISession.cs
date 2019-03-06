using ChessClock.Kernel.Enums;

namespace ChessClock.Kernel.Invariance
{
    public interface ISession
    {
        string Id { get; }
        SessionStatus Status { get; }
        string UserId { get; }
        IPlayer CurrentPlayer { get; }

        ISession WithStatus(SessionStatus status);
        ISession WithCurrentPlayer(IPlayer player);
    }
}