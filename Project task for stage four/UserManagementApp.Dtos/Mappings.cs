using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagementApp.Domain.Entities;

namespace UserManagementApp.Dtos
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
