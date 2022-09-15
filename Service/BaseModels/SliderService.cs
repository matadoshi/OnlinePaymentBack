using DomainModels.Entities;
using Repository.Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.BaseModels
{
    public class SliderService : ISliderService
    {
        private readonly IRepository<Slider> _repository;
        public SliderService(IRepository<Slider> repository)
        {
            _repository = repository;
        }
        public async Task<IList<Slider>> GetSlider()
        {
            try
            {
                IList<Slider> slider = await _repository.GetAllAsync();
                return slider;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
