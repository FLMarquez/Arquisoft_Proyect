using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface ILoginUserRepository
    {
        Task<int> Exist(UserDto user);
        Task<bool> RestorePassword(UserDto user);
    }
    public class LoginUserRepository : ILoginUserRepository
    {

        private readonly string connectionString;

        public LoginUserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<int> Exist(UserDto user)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                var userId = await conn.QueryFirstOrDefaultAsync<int>(@"
            SELECT UserId FROM Users WHERE Password = @Password AND Mail = @Mail AND UserStateId = 1;", user);
                Console.WriteLine("Query Exist from LoginUserRepository: " + userId);
                return userId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error from LoginUserRepository Exist: " + ex.Message);
            }

            return 0; // Valor predeterminado si no se encuentra el usuario
        }

        public async Task<bool> RestorePassword(UserDto user)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                var affectedRows = await conn.ExecuteAsync(@"
            UPDATE Users SET Password = @DocumentNumber WHERE DocumentNumber = @DocumentNumber AND Mail = @Mail AND Telephone = @Telephone AND UserStateId = 1;", user);
                Console.WriteLine("Rows affected in RestorePassword: " + affectedRows);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in RestorePassword: " + ex.Message);
            }

            return false;
        }


    }


}
