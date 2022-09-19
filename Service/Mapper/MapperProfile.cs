using AutoMapper;
using DomainModels.PaymentModels;
using Service.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Category, CategoryGetDto>().ReverseMap();
        }
    }
}
