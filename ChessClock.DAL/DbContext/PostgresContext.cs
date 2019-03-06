using Microsoft.EntityFrameworkCore;
using ChessClock.DAL.Models;

namespace ChessClock.DAL
{
    public class PostgresContext : DbContext
    {
        public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }

        public DbSet<DalSession> Sessions { get; set; }

        public DbSet<DalMove> Moves { get; set; }

        public DbSet<DalPlayer> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ConfigureDalMove(builder);
            ConfigureDalPlayer(builder);
            ConfigureDalSession(builder);

            base.OnModelCreating(builder);
        }

        private void ConfigureDalMove(ModelBuilder builder)
        {
            builder.Entity<DalMove>()
                .HasOne(m => m.Player)
                .WithMany(p => p.Moves)
                .HasForeignKey(m => m.PlayerId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);                
        }

        private void ConfigureDalPlayer(ModelBuilder builder)
        {
            builder.Entity<DalPlayer>()
                .HasOne(p => p.Session)
                .WithMany(s => s.Players)
                .HasForeignKey(p => p.SessionId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureDalSession(ModelBuilder builder)
        {
            builder.Entity<DalSession>()
                .HasOne(s => s.CurrentPlayer)
                .WithOne()
                .HasForeignKey<DalSession>(s => s.CurrentPlayerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);                
        }
    }
}
