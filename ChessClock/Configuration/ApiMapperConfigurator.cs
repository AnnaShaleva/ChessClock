using AutoMapper;
using ChessClock.Kernel.Entities;
using ChessClock.Models;

namespace ChessClock.Configuration
{
    internal class ApiMapperConfigurator
    {
        private readonly IMapperConfigurationExpression _expression;

        public IMapperConfigurationExpression AddConfiguration() => _expression;

        public ApiMapperConfigurator(IMapperConfigurationExpression expression)
        {
            ConfigureMappingApiInputSession(expression);

            _expression = expression;
        }

        private void ConfigureMappingApiInputSession(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<ApiInputSession, Session>()
                .ForMember(dest => dest.CurrentPlayer, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.Ignore());                
        }
    }
}
