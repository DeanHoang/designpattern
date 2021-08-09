using Demo.Service.IApiService;
using Demo.Service.Models;
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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<ProductModel> GetProducts()
        {
            return _productService.GetProducts();
        }
        [HttpGet("{id}")]
        public ProductModel GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }

        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        [HttpPost]
        public ProductModel AddProduct(ProductModel productModel)
        {
            return _productService.AddProduct(productModel);
        }
        [HttpPut("{id}")]
        public ProductModel UpdateProduct(int id,ProductModel product)
        {
            return _productService.UpdateProduct(id, product);
        }
    }
}
