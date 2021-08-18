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
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<UserModel> GetUsers()
        {
            return _userService.GetUsers();
        }
        /// <summary>
        /// Get User By Id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public UserModel GetUser(int id)
        {
            return _userService.GetUser(id);
        }

        /// <summary>
        /// Add a new User
        /// </summary>
        ///<remarks>
        ///
        /// POST /User
        /// {
        /// 
        ///     "username":"newuser",
        ///     
        ///     "email":"newuser@email.com",
        ///     
        ///     "password":"12345678",
        ///     
        ///     "confirmpassword":"12345678",
        ///     
        ///     "role":"Member"
        /// }
        /// </remarks>
        /// <param name="user"></param>
        /// <returns>New Created User</returns>
        /// <response code="200">Returns the newly created user</response>
        /// <response code="400">Null User</response>
        [HttpPost]
        [ProducesResponseType(typeof(UserModel), 200)]
        [ProducesResponseType(typeof(UserModel), 400)]
        public UserModel AddUser(UserModel user)
        {
            return _userService.AddUser(user);
        } 
        /// <summary>
        /// Delete a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public bool DeleteUser(int id)
        {
            return _userService.DeleteUser(id);
        }
        /// <summary>
        /// Update an existing User
        /// </summary>
        /// <param name="id"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public UserModel UpdateUser(int id,UserModel user)
        {
            return _userService.UpdateUser(id, user);
        }
    }
}
