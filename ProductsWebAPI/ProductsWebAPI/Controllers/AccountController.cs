using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ProductsWebAPI.Controllers
{
    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.Extensions.Configuration;
    using ProductsWebAPI.Models;
    using System.Reflection;

    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService<User, RegisterModel> _accountService;
        private IConfiguration _configuration;
        public AccountController(IAccountService<User, RegisterModel> accountService, IConfiguration configuration)
        {
            _accountService = accountService;
            _configuration = configuration;
        }

        // POST api/<AccountController>
        [HttpPost("Register")]
        public AuthenticateResponse Register([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid && _accountService.GetAll().SingleOrDefault(x => x.Login == registerModel.Login) == null)
            {
                string token = _configuration(user);

                return new AuthenticateResponse(_accountService.Add(registerModel), token);
            }
            else
            {
                return null;
            }
        }

        // POST api/<AccountController>
        [HttpPost("Login")]
        public AuthenticateResponse Login([FromBody] UserModel userModel)
        {
            var user = _accountService.GetAll().FirstOrDefault(x => x.Login == userModel.Login && x.Password == userModel.Password.GetHashCode());

            if (user != null)
            {
                return null;
            }

            string token = _configuration (user);

            return new AuthenticateResponse(user.Login, token);
        }
    }
}
