using AutoMapper;
using MovieStore.Core.Entity;
using MovieStore.Core.Model.Request.Actor;
using MovieStore.Core.Model.Request.Movie;
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
            CreateMap<ActorCreateRequest, Actor>(); // elindeki,hedef
            CreateMap<ActorUpdateRequest, Actor>();
            CreateMap<MovieCreateRequest, Movie>(); // elindeki,hedef
            CreateMap<MovieUpdateRequest, Movie>();
        }
    }
}
