using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace ProductsWebAPI.Controllers
{
    using Core.Entities;
    using Core.Interfaces;
    using Microsoft.Extensions.Configuration;
    using ProductsWebAPI.Helpers;
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
        public IActionResult Register([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                if (_accountService.GetAll().SingleOrDefault(x => x.Login == registerModel.Login) == null)
                {
                    var user = _accountService.Add(registerModel);
                    string token = _configuration.GenerateJwtToken(user);

                    return Ok(new AuthenticateResponseModel(user.Login, token));
                }
                else
                {
                    return BadRequest(new { message = "User with this login is already exist." });
                }
            }

            return BadRequest(new { message = "Invalid parameters." });
        }

        // POST api/<AccountController>
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserModel userModel)
        {
            var user = _accountService.GetAll().FirstOrDefault(x => x.Login == userModel.Login && x.Password == userModel.Password.GetHashCode());

            if (user == null)
            {
                return BadRequest(new { message = "Login or password is incorrect" });
            }

            string token = _configuration.GenerateJwtToken(user);

            return Ok(new AuthenticateResponseModel(user.Login, token));
        }

        /*
        // GET api/<AccountController>
        [HttpGet("Logout")]
        public bool Logout()
        {
            try
            {
                _configuration.toke
            }
            catch (Exception)
            {
                return false;
            }
        }
        */
    }
}
