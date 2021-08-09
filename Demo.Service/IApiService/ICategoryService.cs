using Demo.Database.Entity;
using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IApiService
{
    public interface ICategoryService
    {
        List<CategoryModel> GetCategories();
        CategoryModel GetCategory(int categoryId);
        CategoryModel UpdateCategory(int categoryId, CategoryModel category);
        CategoryModel AddCategory( CategoryModel category);
        bool DeleteCategory(int categoryId);

    }
}
