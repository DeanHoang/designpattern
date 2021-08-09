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
        public UserModel AddUser(UserModel user);
    }
}
