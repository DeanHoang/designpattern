using Demo.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IRepositories
{
    public interface IUserRepository
    {
        public List<Product> GetProductsByUserId(int userId);
        public List<User> GetUsers();
        public User GetUser(int userId);
        public User AddUser(User user);

        public User UpdateUser(int userId, User user);
        public bool DeleteUser(int userId);
    }
}
