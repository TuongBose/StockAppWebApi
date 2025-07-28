using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetUserById(int userId);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(RegisterViewModel registerViewModel);
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
