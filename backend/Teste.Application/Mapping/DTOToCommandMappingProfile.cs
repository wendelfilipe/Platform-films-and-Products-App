using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Teste.Application.DTOs;
using Teste.Application.Movies.Commands;
using Teste.Application.Users.Commands;

namespace Teste.Application.Mapping
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<MovieDTO, MovieCreateCommand>();
            CreateMap<MovieDTO, MovieUpdateCommand>();

            CreateMap<UserDTO, UserCreateCommand>();
        }
    }
}