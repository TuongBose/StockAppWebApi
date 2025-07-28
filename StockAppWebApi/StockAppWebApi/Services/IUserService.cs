using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel registerViewModel);
        Task<User?> GetUserById(int userId);
        // jwt string
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
