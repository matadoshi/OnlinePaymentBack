using DomainModels.PaymentModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO
{
    public class CategoryGetDto
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public IList<Attributes> Attributes { get; set; }
    }
}
