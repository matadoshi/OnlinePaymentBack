using DomainModels.PaymentModels;
using Service.DTO.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO.Category
{
    public class CategoryGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public List<AttributesGetDto> Attributes { get; set; }
    }
}
