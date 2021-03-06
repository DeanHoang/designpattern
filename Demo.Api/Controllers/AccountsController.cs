using Demo.Service.Constant;
using Demo.Service.IApiService;
using Demo.Service.Models.JWT;
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
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        [HttpPost("Admin/Login")]
        public IActionResult AdminLogin(AccountModel accountModel)
        {
            var response = _accountService.AdminLogin(accountModel.Email, accountModel.Password);
            if (response == null)
            {
                return StatusCode(404, Constants.NotFound);
            }
            else
            {
                return StatusCode(200, response);
            }
        }
        [HttpPost("Member/Login")]
        public IActionResult MemberLogin(AccountModel accountModel)
        {
            var response = _accountService.MemberLogin(accountModel.Email, accountModel.Password);
            if (response == null)
            {
                return StatusCode(404, Constants.NotFound);
            }
            else
            {
                return StatusCode(200, response);
            }
        }
    }
}
