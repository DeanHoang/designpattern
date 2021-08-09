using Demo.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IRepositories
{
    public interface ICategoryRepository
    {
        public List<Category> GetCategories();
        public Category GetCategory(int categoryId);
        public Category AddCategory(Category category);
        public Category UpdateCategory(int categoryId, Category category);
        public bool DeleteCategory(int categoryId);
    }
}
