using AutoMapper;
using Mini_projeto_Book_Samsys.Models;
using Mini_projeto_Book_Samsys.Models.DTOs;

namespace Mini_projeto_Book_Samsys.Mappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
        }    
    }
}
