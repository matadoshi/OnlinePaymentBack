using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO.Category
{
    public class CategoryPutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
