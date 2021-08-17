using AutoMapper;
using Demo.Database.Entity;
using Demo.Service.ApiService;
using Demo.Service.Common;
using Demo.Service.IApiService;
using Demo.Service.IRepositories;
using Demo.Service.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ProductControllerTest
{
    public class ProductServiceTesting
    {
        private Mock<IProductRepository> _productRepository = new Mock<IProductRepository>();
        private IProductService _productService;
        private IMapper _mapper;
        public ProductServiceTesting()
        {
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());
            });
            _mapper = mockMapper.CreateMapper();

            _productService = new ProductService(_productRepository.Object, _mapper);
        }
        public List<ProductModel> _listProduct = new List<ProductModel>()
            {
                new ProductModel(){ Id= 1,Description="hello1",Name="shirt1",NumInStock=101,IsAvailable=1,Price=101},
                new ProductModel(){ Id= 2,Description="hello2",Name="shirt2",NumInStock=102,IsAvailable=1,Price=102},
                new ProductModel(){ Id= 3,Description="hello3",Name="shirt3",NumInStock=103,IsAvailable=1,Price=103},
                new ProductModel(){ Id= 4,Description="hello4",Name="shirt4",NumInStock=104,IsAvailable=1,Price=104},
            };

        //test get all
        [Fact]
        public void ProductService_GetAll_Test()
        {
            //arrage           
            var list = _mapper.Map<List<Product>>(_listProduct);
            _productRepository.Setup(p => p.GetProducts()).Returns(list);
            //act
            var result = _productService.GetProducts() as List<ProductModel>;

            //assert
            Assert.NotNull(result);
            Assert.Equal(4, result.Count);
        }

        //test get 1 product
        [Fact]
        public void ProductService_GetById_Test()
        {
            //arrage
            var item = _listProduct[1];
            _productRepository.Setup(p => p.GetProduct(It.IsAny<int>())).Returns(_mapper.Map<Product>(item));

            //act
            var result = _productService.GetProduct(item.Id) as ProductModel;

            Assert.NotNull(result);
            Assert.Equal(item.Id, result.Id);
        }

        //test add a product
        [Fact]
        public void ProductService_AddProduct_Test()
        {
            ProductModel product = new ProductModel();
            product.Id = 5;
            product.Name = "shirt5";
            product.Price = 105;
            product.Description = "Hello5";
            product.NumInStock = 105;

            _productRepository.Setup(p => p.AddProduct(It.IsAny<Product>())).Returns(_mapper.Map<Product>(product));

            var result = _productService.AddProduct(product);
            Assert.NotNull(result);
            Assert.Equal(result.Id, product.Id);

        }

        [Theory]
        [InlineData(false)]
        public void ProductService_DeleteProduct_Test(bool check)
        {
            _productRepository.Setup(c => c.DeleteProduct(It.IsAny<int>())).Returns(check);

            var result = _productService.DeleteProduct(1);

            Assert.Equal(result,check);
        }

    }
}
