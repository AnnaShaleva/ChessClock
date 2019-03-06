namespace ChessClock.Kernel.Invariance
{
    public interface IPlayer
    {
        int Id { get; }
        string Name { get; }
        string SessionId { get; }
        int NumberInQueue { get; }
    }
}