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
        public User AddUser(User user);
    }
}
