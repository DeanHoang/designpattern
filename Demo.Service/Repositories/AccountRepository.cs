using Demo.Database.Entity;
using Demo.Service.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly AppDBContext _context;
        public AccountRepository(AppDBContext appDBContext)
        {
            _context = appDBContext;
        }
        public User AuthenticateAdmin(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Role.Contains("admin"));
            return user;
        }
        
        public User AuthenticateMember(string email, string password)
        {
           var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password && u.Role.Contains("Member"));

            return user;
        }

        public User FindByEmail(string email)
        {
            var user = (from u in _context.Users
                        where u.Email == email
                        select u).FirstOrDefault();
            return user;
        }

        public async Task SaveResetPasswordToken(int id, string token)
        {
            var user = await _context.Users.FindAsync(id);
            user.ResetPasswordToken = token;
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public void UpdateUser(User user)
        {
            var userUpdate = _context.Users.FirstOrDefault(u => u.Email == user.Email);
            userUpdate.Password = user.Password;
            _context.Users.Update(userUpdate);
            _context.SaveChanges();
        }
    }
}
