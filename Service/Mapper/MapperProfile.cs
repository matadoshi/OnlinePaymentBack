using AutoMapper;
using DomainModels.Entities;
using DomainModels.PaymentModels;
using Service.DTO.Category;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Service.DTO.Slider;

namespace Service.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category,CategoryGetDto>().ReverseMap();
            CreateMap<Category,CategoryPutDto>().ReverseMap();
            CreateMap<Category,CategoryPostDto>().ReverseMap();
            CreateMap<Slider,SliderGetDto>().ReverseMap();
            CreateMap<Slider,SliderPostDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
        }
    }
}
