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
        /// <summary>
        /// Get all Products
        /// </summary>
        /// 
        /// <response code="404">If result is not found.</response>
        /// <response code="400">If Invalid request .</response>
        /// 
        /// <returns></returns>
        [HttpGet]
        public List<ProductModel> GetProducts()
        {
            return _productService.GetProducts();
        }
        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <param name="id"></param>
        /// <response code="404">If result is not found.</response>
        /// <response code="400">If Invalid request .</response>
        /// <returns></returns>
        [HttpGet("{id}")]
        public ProductModel GetProduct(int id)
        {
            return _productService.GetProduct(id);
        }
        /// <summary>
        /// Delete a Product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <response code="204">No content</response>
        /// <response code="201">Delete completely</response>
        [HttpDelete("{id}")]
        public bool DeleteProduct(int id)
        {
            return _productService.DeleteProduct(id);
        }

        /// <summary>
        /// Add a new Product 
        /// </summary>
        /// <remarks>
        /// 
        /// POST /Product
        /// {
        ///   
        ///     "name":"newProduct",
        ///     
        ///     "price":100,
        ///     
        ///     "NumInStock":10,
        ///     
        ///     "Description" : "A description for product"
        /// 
        ///     "IsAvailable": 1
        ///     
        ///   };
        ///   
        /// </remarks>
        /// <param name="productModel"></param>
        /// <returns>New Created Product</returns>
        /// <response code="200">Returns the newly created product</response>
        /// <response code="400">Null Product</response>
        [HttpPost]
        public ProductModel AddProduct(ProductModel productModel)
        {
            return _productService.AddProduct(productModel);
        }
        /// <summary>
        /// Update a product
        /// </summary>
        /// <param name="id"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public ProductModel UpdateProduct(int id,ProductModel product)
        {
            return _productService.UpdateProduct(id, product);
        }
    }
}
