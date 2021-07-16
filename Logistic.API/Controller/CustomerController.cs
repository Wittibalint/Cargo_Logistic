using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Logistic.Data.Entities;
using Logistic.Data.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Logistic.API.Controller
{
    [Route("api/auth")]
    [ApiController]

    
    public class CustomerController : ControllerBase
    {
        ILogisticService dataService;

        public CustomerController(ILogisticService service)
        {
            dataService = service;
        }
        [HttpPost, Route("login")]
        public async Task<ActionResult> Login([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("Invalid client request");
            }
            if (user.Email == "admin")
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44376",
                    audience: "http://localhost:44376",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, user = 0, admin = "y" });
            }
            List<User> users = (List<User>)await dataService.GetUsersAsync();
            User validUser = users.Select(u => u).Where(u => u.Email == user.Email).Single();
            if (user != null && user.Password == validUser.Password)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "http://localhost:44376",
                    audience: "http://localhost:44376",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new { Token = tokenString, user = validUser.Id, admin = "n" });
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
