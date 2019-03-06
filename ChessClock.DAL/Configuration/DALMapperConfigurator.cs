using AutoMapper;
using ChessClock.DAL.Models;
using ChessClock.Kernel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChessClock.DAL.Configuration
{
    public class DALMapperConfigurator
    {
        private readonly IMapperConfigurationExpression _expression;

        public DALMapperConfigurator(IMapperConfigurationExpression expression)
        {
            ConfigureMappingDalMove(expression);
            ConfigureMappingDalPlayer(expression);
            ConfigureMappingDalSession(expression);

            _expression = expression;
        }

        public IMapperConfigurationExpression AddConfiguration() => _expression;

        private void ConfigureMappingDalMove(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Move, DalMove>()
                .ReverseMap();
        }

        private void ConfigureMappingDalPlayer(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Player, DalPlayer>()
                .ForMember(dest => dest.Session, opt => opt.Ignore())
                .ReverseMap();
        }

        private void ConfigureMappingDalSession(IMapperConfigurationExpression expression)
        {
            expression.CreateMap<Session, DalSession>()
                .ForMember(dest => dest.Players, opt => opt.Ignore());

                //.ForMember(dest => dest.CurrentPlayer, opt => opt.Condition(src => src.CurrentPlayer != null));
                //.ForMember(dest => dest.CurrentPlayer, opt => opt.NullSubstitute(new DalPlayer { Id = 5, Name = "bld", SessionId = "srfse", Moves = null, NumberInQueue = 5}));
        }
    }
}
