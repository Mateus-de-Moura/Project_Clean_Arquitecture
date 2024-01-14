using AutoMapper;
using Project.Core.Entities;
using Project.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Mappers
{
    public class DtoToDomain : Profile
    {
        public DtoToDomain()
        {
                CreateMap<UserAddDto, User>();
        }
    }
}
