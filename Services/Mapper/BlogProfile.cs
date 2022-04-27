using AutoMapper;
using Database.Models;
using Services.DTO;
using Services.DTO.StoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Mapper
{
    public class BlogProfile : Profile
    {
        public BlogProfile()
        {
            //CreateMap<StoryDTO, Story>().ForMember(dest =>
            //dest.AuthorId,
            //opt => opt.MapFrom(src => src.AuthorId)).ReverseMap();
            //CreateMap<Story, StoryDTO>().ForMember(dest =>
            //dest.AuthorId,
            //opt => opt.MapFrom(src => src.AuthorId)).ReverseMap();

            CreateMap<Story, UpdateStoryDto>().ReverseMap();
            CreateMap<Story, CreateStoryDto>().ReverseMap();
            CreateMap<Story, GetStoryDto>().ReverseMap();
            CreateMap<Author, AuthorDTO>().ReverseMap();
            CreateMap<Author, GetAuthorDTO>().ReverseMap();
            CreateMap<Author, SignInAuthorDTO>().ReverseMap();
            CreateMap<Author, SignUpAuthorDTO>().ReverseMap();
            CreateMap<Author, UpdateAuthorDTO>().ReverseMap();
        }
       
    }
}
