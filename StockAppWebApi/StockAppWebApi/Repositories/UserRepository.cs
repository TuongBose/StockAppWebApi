using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace StockAppWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;
        private readonly IConfiguration _configuration;

        public UserRepository(DataBaseContext dataBaseContext, IConfiguration configuration)
        {
            _dataBaseContext = dataBaseContext;
            _configuration = configuration;
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            // Đoạn này sẽ gọi 1 procedure trong SQL
            string sql = "EXECUTE dbo.RegisterUser " +
                "@username, " +
                "@password, " +
                "@email, " +
                "@phone," +
                "@full_name ," +
                "@date_of_birth ," +
                "@country";
            IEnumerable<User> result = await _dataBaseContext.Users.FromSqlRaw(sql,
                new SqlParameter("@username", registerViewModel.Username ?? ""),
                new SqlParameter("@password", registerViewModel.Password),
                new SqlParameter("@email", registerViewModel.Email),
                new SqlParameter("@phone", registerViewModel.Phone ?? ""),
                new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
                new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
                new SqlParameter("@country", registerViewModel.Country))
                .ToListAsync();

            User? user = result.FirstOrDefault();
            return user;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _dataBaseContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _dataBaseContext.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _dataBaseContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            // Đoạn này sẽ gọi 1 procedure trong SQL
            string sql = "EXECUTE dbo.CheckLogin " +
                "@email, " +
                "@password";
            IEnumerable<User> result = await _dataBaseContext.Users.FromSqlRaw(sql,
                new SqlParameter("@email", loginViewModel.Email),
                new SqlParameter("@password", loginViewModel.Password))
                .ToListAsync();

            User? user = result.FirstOrDefault();

            if (user != null)
            {
                // tao ra jwt string de gui cho client
                // Neu xac thuc thanh cong, tao JWT token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"] ?? "");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha256Signature
                        )
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                return jwtToken;
            }
            else
            {
                throw new Exception("Wrong email or password");
            }
        }
    }
}
