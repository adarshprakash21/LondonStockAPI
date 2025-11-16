using LondonStockAPI.Controllers;
using LondonStockAPI.DataBaseContext;
using LondonStockAPI.Dto;
using LondonStockAPI.Interface;
using LondonStockAPI.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LondonStockAPI.AuthService
{
    public class AuthService: IAuthService
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IApplicationDbContext dbContext, IConfiguration configuration, ILogger<AuthService> logger)
        {
            _configuration = configuration;
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<UserDto> Register(User user)
        {
            UserDto userDto = new UserDto()
            {
                Username = user.Username,
                HashedPassword = new PasswordHasher<User>()
                    .HashPassword(user, user.Password)
            };

            var newUser= new Entity.User()
            {
                Id = new Guid(),
                Username = userDto.Username,
                HashedPassword = userDto.HashedPassword
            };

            _dbContext.User.Add(newUser);
            await _dbContext.SaveChangesAsync();
            _logger.LogTrace(user.Username + " User Registered");
            return userDto;
        }

        public async Task<string> Login(UserDto userDto)
        {
            var dbUser= await _dbContext.User.FirstOrDefaultAsync(x=> x.Username == userDto.Username);
            
            if (dbUser == null)
            {
                _logger.LogTrace(userDto.Username + " User not found");
                return "User not found";
            }
                

            var user = new User()
            {
                Username = dbUser.Username,
                Password = dbUser.HashedPassword
            };
            if ( new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, userDto.HashedPassword)== PasswordVerificationResult.Failed)
            {
                _logger.LogTrace(userDto.Username + " Wrong Password");
                return "Wrong Password";
            }

            var token = await CreateToken(user);
            _logger.LogTrace(userDto.Username + "token generated");
            return token;
        }


        private async Task<string> CreateToken(User userDto)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, userDto.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")!));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("Jwt:Issuer"),
                audience: _configuration.GetValue<string>("Jwt:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
        }

    }
}
