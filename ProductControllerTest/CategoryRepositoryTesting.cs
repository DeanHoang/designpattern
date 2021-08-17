using Demo.Database.Entity;
using Demo.Service.IRepositories;
using Demo.Service.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductControllerTest
{
    public class CategoryRepositoryTesting
    {
        ICategoryRepository categoryRepository;
        AppDBContext context;

        public CategoryRepositoryTesting()
        {
            var options = new DbContextOptionsBuilder<AppDBContext>()
                .UseInMemoryDatabase(databaseName: "test")
                .Options;
            context = new AppDBContext(options);
            categoryRepository = new CategoryRepository(context);
            context.Categories.Add(new Category
            {
                Id = 1,
                Name = "Shirt"
            });
            context.Categories.Add(new Category
            {
                Id = 2,
                Name = "Pant"
            });
            context.SaveChanges();
        }

        [Fact]
        public void CategoryRepository_GetAllCategories_Test()
        {

            var list = categoryRepository.GetCategories().ToList();

            Assert.NotNull(list);
            Assert.Equal(2, list.Count());
        }

        [Fact]
        public void CategoryRepository_GetCategoryById_Test()
        {
            var category = categoryRepository.GetCategory(2);

            Assert.NotNull(category);
            Assert.Equal(2, category.Id);
            Assert.Equal("Pant", category.Name);
        }

        [Fact]
        public void CategoryRepository_AddCategory_Test()
        {
            Category category = new Category()
            {
                Id = 3,
                Name = "test"
            };

            var result = categoryRepository.AddCategory(category);
            Assert.NotNull(result);
            Assert.Equal(3, context.Categories.Count());
            Assert.Equal("test", result.Name);
            Assert.Equal(3, result.Id);
        }

        [Fact]
        public void CategoryRepository_DeleteCategory_Test()
        {
            var result = categoryRepository.DeleteCategory(1);

            Assert.True(result);
            Assert.Equal(1, context.Categories.Count());
        }
        [Fact]
        public void CategoryRepository_UpdateCategory_Test()
        {
            Category category = new Category()
            {
                Id = 1,
                Name = "test"
            };
            var result = categoryRepository.UpdateCategory(category.Id, category);

            Assert.NotNull(result);
            Assert.Equal("test", result.Name);
            Assert.Equal(1, result.Id);
        }
    }
}
