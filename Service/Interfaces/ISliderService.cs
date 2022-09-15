using DomainModels.Entities;
using Repository.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface ISliderService
    {
        Task<IList<Slider>> GetSlider();
    }
}
