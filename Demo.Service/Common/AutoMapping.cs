using AutoMapper;
using Demo.Database.Entity;
using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Common
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<UserModel, User>();
            CreateMap<User, UserModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<CategoryModel, Category>();
            CreateMap<Category, CategoryModel>();
        }
    }
}
