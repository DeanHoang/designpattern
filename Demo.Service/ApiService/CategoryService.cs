using AutoMapper;
using Demo.Database.Entity;
using Demo.Service.IApiService;
using Demo.Service.IRepositories;
using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.ApiService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository,IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public CategoryModel AddCategory(CategoryModel category)
        {

            var categoryAdd = _mapper.Map<Category>(category);
            var categoryResult = _categoryRepository.AddCategory(categoryAdd);
            return category;
        }

        public bool DeleteCategory(int categoryId)
        {
            var categoryDel = _categoryRepository.GetCategory(categoryId);
            if (categoryDel != null)
            {
                var _cate = _mapper.Map<Category>(categoryDel);
                _categoryRepository.DeleteCategory(_cate.Id);
                return true;
            }
            return false;
        }

        public List<CategoryModel> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            var categoriesResult = _mapper.Map<List<CategoryModel>>(categories);
            return categoriesResult;
        }

        public CategoryModel GetCategory(int categoryId)
        {
            var category = _categoryRepository.GetCategory(categoryId);
            var categoryResult = _mapper.Map<CategoryModel>(category);
            return categoryResult;
        }

        public CategoryModel UpdateCategory(int categoryId, CategoryModel category)
        {
            if (category.Id == categoryId)
            {
                var categoryToUpdate = _mapper.Map<Category>(category);
                _categoryRepository.UpdateCategory(categoryId,categoryToUpdate);
                return category;
            }
            else
            {
                return null;
            }
        }
    }
}
