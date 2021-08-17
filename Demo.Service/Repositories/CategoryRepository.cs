using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Demo.Database.Entity;
using Demo.Service.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace Demo.Service.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDBContext _context;
        public CategoryRepository(AppDBContext context)
        {
            _context = context;
        }

        public Category AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return category;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

        public bool DeleteCategory(int categoryId)
        {
            try
            {
                var category = GetCategory(categoryId);
                if (category != null)
                {
                    _context.Categories.Remove(category);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return false;
        }

        public List<Category> GetCategories()
        {
            try
            {
                return _context.Categories.ToList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Category GetCategory(int categoryId)
        {
            try
            {
                var category = _context.Categories.Include(p => p.Products)
                    .FirstOrDefault(c => c.Id == categoryId);
                return category;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
            
        }

        public Category UpdateCategory(int categoryId, Category category)
        {
            try
            {
                var categoryUpdate = GetCategory(categoryId);
                if (categoryUpdate != null && categoryUpdate.Id == category.Id)
                {
                    categoryUpdate.Name = category.Name;
                    _context.SaveChanges();
                    return categoryUpdate;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}