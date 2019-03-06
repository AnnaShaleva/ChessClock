using Microsoft.Extensions.DependencyInjection;
using ChessClock.BLL.Services;
using ChessClock.Kernel.Services;

namespace ChessClock.BLL.Configuration
{
    public static class BLLServicesRegistrator
    {
        public static void AddBLL(this IServiceCollection services)
        {
            services.AddTransient<ISessionService, SessionService>();
            services.AddTransient<IQueryService, QueryService>();
            services.AddTransient<IPlayerService, PlayerService>();
            services.AddTransient<IMoveService, MoveService>();
        }
    }
}
