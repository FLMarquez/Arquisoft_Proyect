using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface ILoginClientRepository
    {
        Task<int> Exist(ClientDto client);
        Task<bool> RestorePassword(ClientDto client);
    }
    public class LoginClientRepository : ILoginClientRepository
    {

        private readonly string connectionString;

        public LoginClientRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<int> Exist(ClientDto client)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                var clientId = await conn.QueryFirstOrDefaultAsync<int>(@"
            SELECT ClientId FROM Clients WHERE Password = @Password AND Mail = @Mail AND ClientStateId = 1;", client);
                Console.WriteLine("Query Exist from ClientLoginRepository: " + clientId);
                return clientId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error from ClientLoginRepository Exist: " + ex.Message);
            }

            return 0; // Valor predeterminado si no se encuentra el cliente
        }

        public async Task<bool> RestorePassword(ClientDto client)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                var affectedRows = await conn.ExecuteAsync(@"
            UPDATE Clients SET Password = @DocumentNumber WHERE DocumentNumber = @DocumentNumber AND Mail = @Mail AND Telephone = @Telephone AND ClientStateId = 1;", client);
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
