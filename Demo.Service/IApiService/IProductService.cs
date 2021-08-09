using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IApiService
{
   public interface IProductService
    {
        public ProductModel GetProduct(int id);
        public List<ProductModel> GetProducts();
        public ProductModel AddProduct(ProductModel productModel);
        public ProductModel UpdateProduct(int id, ProductModel productModel);
        public bool DeleteProduct(int id);
    }
}
