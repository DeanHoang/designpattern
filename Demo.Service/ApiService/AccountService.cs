using Demo.Database.Entity;
using Demo.Service.Bcrypt;
using Demo.Service.Constant;
using Demo.Service.IApiService;
using Demo.Service.IRepositories;
using Demo.Service.JWT;
using Demo.Service.Models.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Service.ApiService
{
    public class AccountService : IAccountService
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IJwtService _jwtService;
        private readonly IBcrypt _bcrypt;
        public AccountService(IAccountRepository accountRepository, IJwtService jwtService, IBcrypt bcrypt)
        {
            _accountRepository = accountRepository;
            _jwtService = jwtService;
            _bcrypt = bcrypt;
        }
        public ResponseTokenModel AdminLogin(string email, string password)
        {
            User user = _accountRepository.AuthenticateAdmin(email, _bcrypt.HashCode(password));
            ResponseTokenModel res = new ResponseTokenModel();
            if (user != null)
            {
                res.Token = _jwtService.GenerateJWT(email, user.Role);
                res.Id = user.Id;
                res.Scope = user.Role;
                return res;
            }
            return null;
        }

        public string ChangePassword(string email, ChangePasswordModel model)
        {
            var user = _accountRepository.FindByEmail(email);
            if (user.Password != _bcrypt.HashCode(model.OldPassword))
            {
                return Constants.OldPasswordIncorrect;
            }
            else
            {
                user.Password = _bcrypt.HashCode(model.NewPassword);
                return Constants.Success;
            }
        }

        public ResponseTokenModel MemberLogin(string email, string password)
        {

            User user = _accountRepository.AuthenticateMember(email, _bcrypt.HashCode(password)); 
            ResponseTokenModel respone = new ResponseTokenModel();
            if (user != null)
            {
                respone.Token = _jwtService.GenerateJWT(email, user.Role);
                respone.Id = user.Id;
                respone.Scope = user.Role;
                return respone;
            }//n
            return null;
        }

        public void ResetPassword(string email, string newPassword, string token)
        {
            var user = _accountRepository.FindByEmail(email);
            if (user.ResetPasswordToken == token)
            {
                user.Password = _bcrypt.HashCode(newPassword);
                user.ResetPasswordToken = null;
                _accountRepository.UpdateUser(user);
            }
        }

        public void SaveResetpasswordToken(int userId, string token)
        {
            _accountRepository.SaveResetPasswordToken(userId, token);   
        }
    }
}
