using Demo.Database.Entity;
using Demo.Service.IRepositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDBContext _context;
        public ProductRepository(AppDBContext context)
        {
            _context = context;
        }
        public Product AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public bool DeleteProduct(int productId)
        {
            try
            {
                var productDel = _context.Products.Find(productId);
                if (productDel != null)
                {
                    _context.Products.Remove(productDel);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return true;
        }

        public Product GetProduct(int productId)
        {
            try
            {
                var product = _context.Products.Include(cat => cat.Categories).ThenInclude(u => u.Products).FirstOrDefault(p => p.Id == productId);
                return product;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _context.Products.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(JsonConvert.SerializeObject(e));
            }
            return null;
        }

        public Product UpdateProduct(int productId, Product product)
        {
            try
            {
                var productUpdate = _context.Products.Find(productId);
                if (productUpdate!=null&& productUpdate.Id == product.Id)
                {
                    productUpdate.Description = product.Description;
                    productUpdate.IsAvailable = product.IsAvailable;
                    productUpdate.Name = product.Name;
                    productUpdate.NumInStock = product.NumInStock;
                    productUpdate.Price = product.Price;
                    _context.SaveChanges();
                    return productUpdate;
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
