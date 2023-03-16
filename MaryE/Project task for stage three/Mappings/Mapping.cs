using AutoMapper;
using LibraryManagementApp.Dtos;
using LibraryManagementApp.Models;

namespace LibraryManagementApp.Mappings
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Authors, AuthorsDto>().ReverseMap();
            CreateMap<Books, BooksDto>().ReverseMap();
        }
    }
}
