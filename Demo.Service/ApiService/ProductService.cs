using AutoMapper;
using Demo.Database.Entity;
using Demo.Service.IApiService;
using Demo.Service.IRepositories;
using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.ApiService
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public ProductService(IProductRepository productRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public ProductModel AddProduct(ProductModel productModel)
        {
            var productToAdd = _mapper.Map<Product>(productModel);
            var product = _productRepository.AddProduct(productToAdd);
            return productModel;
        }

        public bool DeleteProduct(int id)
        {
            var productDel = _productRepository.GetProduct(id);
            if(productDel != null)
            {
                var product = _mapper.Map<Product>(productDel);
                _productRepository.DeleteProduct(product.Id);
                return true;
            }
            return false;
        }

        public ProductModel GetProduct(int id)
        {
            var product = _productRepository.GetProduct(id);
            if(product != null)
            {
                var productResult = _mapper.Map<ProductModel>(product);
                return productResult;
            }
            return null;
        }

        public List<ProductModel> GetProducts()
        {
            var products = _productRepository.GetProducts();
            var productsResult = _mapper.Map<List<ProductModel>>(products);
                return productsResult;
        }

        public ProductModel UpdateProduct(int id, ProductModel productModel)
        {
            if(productModel.Id == id)
            {
                var productUpdate = _mapper.Map<Product>(productModel);
                _productRepository.UpdateProduct(id, productUpdate);
                return productModel;
            }
            return null;
        }
    }
}
