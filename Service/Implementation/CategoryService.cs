using AutoMapper;
using DomainModels.PaymentModels;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;
using Repository.Repository.Implementation;
using Repository.Repository.Interfaces;
using Service.DTO;
using Service.DTO.Category;
using Service.Exceptions;
using Service.Extentions;
using Service.Interfaces;
using Service.Mapper;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementation
{
    public class CategoryService:ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(CategoryPostDto item)
        {
            if (await _categoryRepository.IsExistsAsync(c => c.Name == item.Name))
            {
                throw new AlreadyExistsException($"{item.Name} Category AlreadyExists");
            }

            Category category = _mapper.Map<Category>(item);
            await _categoryRepository.AddAsync(category);
        }
        public async Task DeleteAsync(int? id)
        {
            if (id == null)
            {
                throw new BadRequestException("Id Is Required");
            }

            Category category = await _categoryRepository.GetCategoryById(id);

            if (category == null)
            {
                throw new NotFoundException($"{category.Name} Not Found");
            }
            if (!category.IsDeleted)
            {
                category.IsDeleted = true;
                category.DeletedAt = CustomTime.currentDate;
                category.UpdatedAt=CustomTime.currentDate;
            }
            else
            {
                category.IsDeleted = false;
                category.DeletedAt = null;
            }
            await _categoryRepository.DeleteAsync(category);
        }
        public async Task<IList<CategoryGetDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            var categoriesDto = _mapper.Map<IList<CategoryGetDto>>(categories);

            return categoriesDto;
        }
        public async Task<IList<CategoryGetDto>> GetCategoriesWithAttributes()
        {
            var categories = await _categoryRepository.GetCategoriesWithAttributes();
            var categoriesDto = _mapper.Map<IList<CategoryGetDto>>(categories);
            return categoriesDto;
        }
        public async Task<CategoryGetDto> GetCategoryById(int? id)
        {
            Category category =await _categoryRepository.GetCategoryById(id);
            var categoriesDto = _mapper.Map<CategoryGetDto>(category);

            return categoriesDto;
        }
        public async Task UpdateAsync(int? id,CategoryPutDto item)
        {
            if (id == null)
            {
                throw new BadRequestException("Id is Required");
            }

            if (item.Id != id)
            {
                throw new BadRequestException("Id is not matched");
            }

            Category category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                throw new NotFoundException($"{category.Name} Not Found");
            }
            if (await _categoryRepository.IsExistsAsync(c => c.Id != item.Id && c.Name == item.Name))
            {
                throw new AlreadyExistsException($"{item.Name} category already Exists");
            }
            category.Name = item.Name;
            category.Image = item.Image;
            category.UpdatedAt = DateTime.UtcNow.AddHours(4);
            await _categoryRepository.UpdateAsync(category);
        }

    }
}
