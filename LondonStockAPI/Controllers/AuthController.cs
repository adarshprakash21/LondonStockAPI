using LondonStockAPI.Dto;
using LondonStockAPI.Interface;
using LondonStockAPI.Model;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LondonStockAPI.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService _authService = authService;
       

        [HttpPost("register")]
        public async Task<ActionResult> Register(User user)
        {
            if (user.Username != null & user.Password != null)
            {
                var result = await _authService.Register(user);
                return Ok(result);
            }
            else
                return Ok("failled");
        }

        [HttpPost("login")]
        public async Task<string> Login(UserDto userDto)
        {
            if (userDto.Username == null || userDto.HashedPassword == null)
                return "User Not Found";
            else
            {
                var token = await _authService.Login(userDto);
                return token;
            }
        }
    }
}
