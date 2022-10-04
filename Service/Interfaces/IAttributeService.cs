using Service.DTO.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IAttributeService
    {
        Task<AttributesGetDto> GetDataForAttributes(int? id);
    }
}
