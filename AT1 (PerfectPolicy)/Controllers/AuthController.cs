using AT1__PerfectPolicy_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Controllers
{
 [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
      
        public IConfiguration _config;
        public QuizContext _context;

        public AuthController(IConfiguration config, QuizContext context)
        {
            _config = config;
            _context = context;
        }

        private UserInfo GetUser(string userName, string passWord)
        {
            UserInfo user = _context.Users.FirstOrDefault(u => u.Username == userName);

            if (user != null && user.Password.Equals(passWord))
            {
                return user;
            }
            return null;
        }

        [HttpPost]
        [Route("GenerateToken")]
        public IActionResult GenerateToken(UserInfo _userData)
        {

            if (_userData != null && _userData.Username != null && _userData.Password != null)
            {
                var user = GetUser(_userData.Username, _userData.Password);

                if (user != null)
                {
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _config["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserInfoID.ToString()),
                    new Claim("UserName", user.Username)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddDays(2),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
