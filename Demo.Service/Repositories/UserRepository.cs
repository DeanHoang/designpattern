using Demo.Database.Entity;
using Demo.Service.Bcrypt;
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
        private readonly IBcrypt _bcrypt;
        public UserRepository(AppDBContext context, IBcrypt bcrypt)
        {
            _context = context;
            _bcrypt = bcrypt;
        }
        public User AddUser(User user)
        {
            try
            {
                var newUser = new User()
                   { 
                        UserName = user.UserName,
                        Email = user.Email,
                        Role = user.Role,
                        Password = _bcrypt.HashCode(user.Password)
                   };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();
                    return newUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public bool DeleteUser(int userId)
        {
            try
            {
                var userDel = _context.Users.Find(userId);
                if(userDel != null)
                {
                    _context.Users.Remove(userDel);
                    _context.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
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

        public User GetUser(int userId)
        {
            try
            {
                return _context.Users.Where(u => u.Id == userId).Include(p=>p.Products).FirstOrDefault();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
            
        }

        public List<User> GetUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public User UpdateUser(int userId, User user)
        {
            try
            {
                var userUpdate = GetUser(userId);
                if(userUpdate != null)
                {
                    userUpdate.Email = user.Email;
                    userUpdate.Password = user.Password;
                    userUpdate.UserName = user.UserName;
                    userUpdate.Role = user.Role;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
