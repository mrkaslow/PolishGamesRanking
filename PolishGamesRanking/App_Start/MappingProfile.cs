using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using PolishGamesRanking.DTOs;
using PolishGamesRanking.Models;

namespace PolishGamesRanking.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Game, GameDto>();
            Mapper.CreateMap<GameDto, Game>()
                .ForMember(c => c.Id, opt => opt.Ignore());
        }

    }
}