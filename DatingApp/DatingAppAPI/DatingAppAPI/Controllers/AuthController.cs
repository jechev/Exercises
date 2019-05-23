using DatingAppAPI.Data;
using DatingAppAPI.Dtos;
using DatingAppAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;

namespace DatingAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _repo;
        private readonly IConfiguration _config;

        public AuthController(IAuthRepository repo, IConfiguration config, IMapper mapper)
        {
            this._mapper = mapper;
            this._repo = repo;
            this._config = config;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDto userForRegisterDto)
        {
            userForRegisterDto.Username = userForRegisterDto.Username.ToLower();

            if (await _repo.UserExist(userForRegisterDto.Username))
            {
                return BadRequest("Username already exists");
            }

            User newUser = _mapper.Map<User>(userForRegisterDto);

            User createdUser = await _repo.Register(newUser, userForRegisterDto.Password);

            UserForDetailedDto userToReturn = _mapper.Map<UserForDetailedDto>(createdUser);

            return CreatedAtRoute("GetUser", new { controller = "Users", id = createdUser.Id}, userToReturn);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userForLoginDto)
        {
            User currentUser = await _repo.Login(userForLoginDto.Username.ToLower(), userForLoginDto.Password);

            if (currentUser == null)
            {
                return Unauthorized();
            }

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,currentUser.Id.ToString()),
                new Claim(ClaimTypes.Name, currentUser.Username)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value));

            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            UserForListDto user = _mapper.Map<UserForListDto>(currentUser);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });

        }

    }
}
