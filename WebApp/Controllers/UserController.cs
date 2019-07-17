using EN.Core.Declarations.Services;
using EN.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.Localization;
using WebApp.Helpers;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IConfiguration _configuration;
        private readonly ISharedResource _sharedResource;
        public UserController(IUserService userService, IConfiguration configuration, ISharedResource sharedResource)
        {
            _userService = userService;
            _configuration = configuration;
            _sharedResource = sharedResource;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UserDto user)
        {
            var userData = _userService.Login(user);
            if (user == null || userData == null)
            {

                return BadRequest(new { message = _sharedResource.Incorrect_Login });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Environment.MachineName);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userData.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new { token = tokenString });
        }
        [HttpPost]
        public IActionResult Create([FromBody]UserDto user)
        {
            var userData = _userService.Create(user);
            if (userData == null)
            {
                return BadRequest();
            }
            return Ok(userData);
        }
    }
}
