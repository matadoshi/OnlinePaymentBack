using AutoMapper;
using Repository.Repository.Interfaces;
using Service.DTO.Attributes;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class AttributeService : IAttributeService
    {
        private readonly IAttributeRepository _repo;
        private readonly IMapper _mapper;
        public AttributeService(IAttributeRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

            public async Task<AttributesGetDto> GetDataForAttributes(int? id)
            {
                var attributes = await _repo.GetDataForAttributes(id);
            
                var attributeDto = _mapper.Map<AttributesGetDto>(attributes);
                return attributeDto;
            }
    }
}
