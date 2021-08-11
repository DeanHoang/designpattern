using Demo.Service.IApiService;
using Demo.Service.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        public List<UserModel> GetUsers()
        {
            return _userService.GetUsers();
            }
        
        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        [HttpPost]
        public UserModel AddUser(UserModel user)
        {
            return _userService.AddUser(user);
        } 

        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public UserModel UpdateUser(int id,UserModel user)
        {
            return _userService.UpdateUser(id, user);
        }
    }
}
