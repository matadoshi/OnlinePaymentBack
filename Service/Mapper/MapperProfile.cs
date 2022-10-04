using AutoMapper;
using DomainModels.Entities;
using DomainModels.PaymentModels;
using Service.DTO.Category;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Service.DTO.Slider;
using Service.DTO.Attributes;

namespace Service.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryPutDto>().ReverseMap();
            CreateMap<Category, CategoryPostDto>().ReverseMap();
            CreateMap<Slider, SliderGetDto>().ReverseMap();
            CreateMap<Slider, SliderPostDto>().ReverseMap();
            CreateMap<User, RegisterDto>().ReverseMap();
            CreateMap<Category, CategoryGetDto>()
                .ForMember(s => s.Name, t => t.MapFrom(x => x.Name))
                .ForMember(s => s.Image, t => t.MapFrom(x => x.Image))
                .ForMember(s => s.Attributes, t => t.MapFrom(x => x.Attributes))
                .ReverseMap();
            CreateMap<Attributes, AttributesGetDto>()
                .ForMember(s => s.Name, t => t.MapFrom(x => x.Name))
                .ForMember(s => s.Image, t => t.MapFrom(x => x.Image))
                .ForMember(s => s.CategoryId, t => t.MapFrom(x => x.CategoryId))
                .ForMember(s => s.PhoneNumber, t => t.MapFrom(x => x.PhoneNumber))
                .ForMember(s => s.AccountNumber, t => t.MapFrom(x => x.AccountNumber))
                .ForMember(s => s.FIN, t => t.MapFrom(x => x.FIN));
                
        }
    }
}
