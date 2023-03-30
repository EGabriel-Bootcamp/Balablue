using AutoMapper;
using UserMan.API.Dto;
using UserMan.Domain.Entities;

namespace UserMan.API.Helper
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<User,UserDto>().ReverseMap();
        }
    }
}
