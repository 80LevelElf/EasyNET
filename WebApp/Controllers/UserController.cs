using EN.Core.Declarations.Services;
using EN.Core.DTO;
using EN.Core.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService _userService;
        readonly IConfiguration _configuration;
        public UserController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody]UserDto user)
        {
            var userData = _userService.Login(user);
            if (user == null || userData == null)
            {
                return BadRequest(new { message = "Username or password incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("EasyNET_is_the_best");
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
