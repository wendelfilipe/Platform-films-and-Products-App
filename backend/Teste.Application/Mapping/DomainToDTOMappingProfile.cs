using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teste.Application.DTOs;
using Teste.Domain.Entites;

namespace Teste.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Movie, MovieDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}