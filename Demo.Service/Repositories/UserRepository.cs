using Demo.Database.Entity;
using Demo.Service.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDBContext _context;
        public UserRepository(AppDBContext context)
        {
            _context = context;
        }
        public User AddUser(User user)
        {
            try
            {
                if (!_context.Users.Contains(user))
                {
                    var newUser = new User()
                    {
                        UserName = user.UserName,
                        Email = user.Email,
                        Role = user.Role,
                    };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    return newUser;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public List<Product> GetProductsByUserId(int userId)
        {
            try
            {
                var user = _context.Users.Include(pro => pro.Products).FirstOrDefault(u => u.Id == userId);
                List<Product> products = new List<Product>();
                foreach (var pro in user.Products)
                    products.Add(pro);
                return products;
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            return null;
        }

    }
}
