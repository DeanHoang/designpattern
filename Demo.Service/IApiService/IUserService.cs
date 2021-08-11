using Demo.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IApiService
{
    public interface IUserService
    {
        public List<UserModel> GetUsers();
        public UserModel GetUser(int id);
        public UserModel AddUser(UserModel user);
        public bool DeleteUser(int id);
        public UserModel UpdateUser(int userid,UserModel user);
        public List<ProductModel> GetProductByUserId(int id);
    }
}
