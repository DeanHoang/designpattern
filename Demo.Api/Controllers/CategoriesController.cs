using Demo.Service.IApiService;
using Demo.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public List<CategoryModel> GetCategories()
        {
           return _categoryService.GetCategories();
        }

        [HttpGet("{id}")]
       public CategoryModel GetCategory(int categoryId)
        {
            return _categoryService.GetCategory(categoryId);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public CategoryModel AddCategory(CategoryModel category)
        {
            return _categoryService.AddCategory(category);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public CategoryModel UpdateCategory(int id, CategoryModel category)
        {
            return _categoryService.UpdateCategory(id, category);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public bool DeleteCategory(int id)
        {
            return _categoryService.DeleteCategory(id);
        }
    }
}
