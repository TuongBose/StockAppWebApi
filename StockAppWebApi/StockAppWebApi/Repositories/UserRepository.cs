using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockAppWebApi.Models;
using StockAppWebApi.ViewModels;

namespace StockAppWebApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext _dataBaseContext;

        public UserRepository(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            // Đoạn này sẽ gọi 1 procedure trong SQL
            string sql = "EXECUTE dbo.RegisterUser @username, @password, @email , @phone , @full_name , @date_of_birth , @country ";
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

        public async Task<User?> GetById(int id)
        {
            return await _dataBaseContext.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _dataBaseContext.Users.FirstOrDefaultAsync(x => x.Username == username);
        }
    }
}
