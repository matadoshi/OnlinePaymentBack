using AutoMapper;
using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.DTO.Slider;
using Service.Exceptions;
using Service.Extentions;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class SliderService : ISliderService
    {
        private readonly IRepository<Slider> _sliderRepository;
        private readonly IMapper _mapper;

        public SliderService(IRepository<Slider> repository, IMapper mapper)
        {
            _sliderRepository = repository;
            _mapper = mapper;
        }

        public async Task AddAsync(SliderPostDto item)
        {
            if (await _sliderRepository.IsExistsAsync(c => c.Name == item.Name))
            {
                throw new AlreadyExistsException($"{item.Name} Category AlreadyExists");
            }

            Slider slider = _mapper.Map<Slider>(item);
            slider.CreatedAt = DateTime.UtcNow.AddHours(4);
            await _sliderRepository.AddAsync(slider);
        }

        public async Task DeleteAsync(int? id)
        {

            if (id == null)
            {
                throw new BadRequestException("Id Is Required");
            }

            Slider slider= await _sliderRepository.GetById(id);

            if (slider == null)
            {
                throw new NotFoundException($"{slider.Name} Not Found");
            }
            if (!slider.IsDeleted)
            {
                slider.IsDeleted = true;
                slider.DeletedAt = CustomTime.currentDate;
                slider.UpdatedAt = CustomTime.currentDate;
            }
            else
            {
                slider.IsDeleted = false;
                slider.DeletedAt = null;
            }
            await _sliderRepository.DeleteAsync(slider);
        }

        public async Task<IList<SliderGetDto>> GetAllAsync()
        {
            try
            {
                var slider = await _sliderRepository.GetAllAsync();
                var dto=_mapper.Map<IList<SliderGetDto>>(slider);
                return dto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task<SliderGetDto> GetSliderById(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int? id, SliderPutDto item)
        {
            if (id == null)
            {
                throw new BadRequestException("Id is Required");
            }

            if (item.Id != id)
            {
                throw new BadRequestException("Id is not matched");
            }

            Slider slider= await _sliderRepository.GetById(id);
            if (slider == null || slider.IsDeleted==true)
            {
                throw new NotFoundException($"{slider.Name} Not Found");
            }
            if (await _sliderRepository.IsExistsAsync(c => c.Id != item.Id && c.Name == item.Name))
            {
                throw new AlreadyExistsException($"{slider.Name} category already Exists");
            }
            slider.Name = item.Name;
            slider.MainTitle=item.MainTitle;
            slider.SubTitle=item.SubTitle;
            slider.Image = item.Image;
            slider.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _sliderRepository.UpdateAsync(slider);
        }
    }
}
