using Demo.Database.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IRepositories
{
    public interface IAccountRepository
    {
        public User AuthenticateAdmin(string email, string password);
        public User AuthenticateMember(string email, string password);
        public Task SaveResetPasswordToken(int id, string token);
        public User FindByEmail(string email);
        public void UpdateUser(User user);
    }
}
