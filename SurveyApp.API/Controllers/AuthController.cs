using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SurveyApp.API.Data;
using SurveyApp.API.Data.Entities;
using SurveyApp.API.Models;

namespace SurveyApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IConfiguration configuration;

        public AuthController(AppDbContext context, IMapper mapper, IConfiguration configuration) : base(context, mapper)
        {
            this.configuration = configuration;
        }

        [HttpPost("token")]
        public async Task<IActionResult> GetToken([FromBody]LoginRequest request)
        {
            var user = await Context.Users.FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);

            if (user == null)
                return Unauthorized();

            //security key
            string securityKey = this.configuration["Jwt:Secret"];
            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing credentials
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //add claims
            var role = user.Role == Role.Admin ? "ADMIN" : "USER";
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Role, user.Role == Role.Admin ? "ADMIN" : "USER"));
            claims.Add(new Claim("role", role));
            claims.Add(new Claim("userId", user.Id.ToString()));

            //create token
            var token = new JwtSecurityToken(
                    issuer: configuration["Jwt:Issuer"],
                    audience: configuration["Jwt:Audience"],
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials
                    , claims: claims
                );

            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }

        [HttpPost("signup")]
        public async Task<IActionResult> SignUp([FromBody]SignUpRequest request)
        {
            if (request == null)
                return BadRequest();

            var user = Mapper.Map<UserDb>(request);

            Context.Users.Add(user);
            await Context.SaveChangesAsync();

            var loginRequest = Mapper.Map<LoginRequest>(request);

            return await GetToken(loginRequest);
        }

    }
}