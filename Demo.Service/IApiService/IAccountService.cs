using Demo.Service.Models.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.IApiService
{
    public interface IAccountService
    {
        public ResponseTokenModel AdminLogin(string email, string password);
        public ResponseTokenModel MemberLogin(string email, string password);
        public void SaveResetpasswordToken(int userId, string token);
        public void ResetPassword(string email, string newPassword, string token);
        public string ChangePassword(string email, ChangePasswordModel model);
    }
}
