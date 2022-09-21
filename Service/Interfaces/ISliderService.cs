using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.DTO.Slider;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISliderService
    {
        Task<IList<SliderGetDto>> GetAllAsync();
        Task AddAsync(SliderPostDto item);
        Task<SliderGetDto> GetSliderById(int? id);
        Task UpdateAsync(int? id, SliderPutDto item);
        Task DeleteAsync(int? id);
    }
}
