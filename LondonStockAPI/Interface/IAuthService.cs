using LondonStockAPI.Dto;
using LondonStockAPI.Model;

namespace LondonStockAPI.Interface
{
    public interface IAuthService
    {
        Task<UserDto> Register(User user);
        Task<string> Login(UserDto user);
    }
}
