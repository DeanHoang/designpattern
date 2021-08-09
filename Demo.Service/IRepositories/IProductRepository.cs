using Demo.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IRepositories
{
    public interface IProductRepository
    {
        public Product GetProduct(int productId);
        public List<Product> GetProducts();
        public Product AddProduct(Product product);
        public Product UpdateProduct(int productId, Product product);
        public bool DeleteProduct(int productId);
    }
}
