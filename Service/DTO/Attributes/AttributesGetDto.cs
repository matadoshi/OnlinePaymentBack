using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO.Attributes
{
    public class AttributesGetDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int CategoryId { get; set; }
        public string SubscriberCode { get; set; }
        public string FIN { get; set; }
        public string AccountNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
}
