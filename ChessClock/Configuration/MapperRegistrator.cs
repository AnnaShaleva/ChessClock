using AutoMapper;
using ChessClock.DAL.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChessClock.Configuration
{
    public static class MapperRegistrator
    {
        public static void AddMapper(this IServiceCollection serviceCollection)
        {
            var mapper = new MapperConfiguration(cfg => cfg.AddApi().AddDal());
            serviceCollection.AddSingleton(mapper.CreateMapper());
        }

        public static IMapperConfigurationExpression AddApi(this IMapperConfigurationExpression expression)
        {
            return new ApiMapperConfigurator(expression).AddConfiguration();
        }

        public static IMapperConfigurationExpression AddDal(this IMapperConfigurationExpression expression)
        {
            return new DALMapperConfigurator(expression).AddConfiguration();
        }
    }
}
