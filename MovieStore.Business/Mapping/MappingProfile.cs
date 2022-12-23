using AutoMapper;
using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieStore.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Actor, ActorCreateRequest>();
            CreateMap<Actor, ActorUpdateRequest>();
        }
    }
}
