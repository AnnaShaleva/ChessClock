using Microsoft.Extensions.DependencyInjection;
using ChessClock.DAL.Repositories;
using ChessClock.Kernel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClock.DAL.Configuration
{
    public static class DALServicesRegistrator
    {
        public static void AddDAL(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IPlayerRepository, PlayerRepository>();
            serviceCollection.AddTransient<ISessionRepository, SessionRepository>();
            serviceCollection.AddTransient<IMoveRepository, MoveRepository>();
        }
    }
}
