using AutoMapper;
using Minuten.Dtos;
using Minuten.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Minuten
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Episode, EpisodeDto>();
            CreateMap<EpisodeDto, Episode>();

            CreateMap<PanelMember, PanelMemberDto>();
            CreateMap<PanelMemberDto, PanelMember>();
        }
    }
}