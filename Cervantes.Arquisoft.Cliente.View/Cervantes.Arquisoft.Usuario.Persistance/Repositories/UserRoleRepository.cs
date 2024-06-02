using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface IUserRoleRepository
    {
        Task<IEnumerable<UserRoleDto>> GetAll();
    }

    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly string connectionString;


        public UserRoleRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<UserRoleDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<UserRoleDto>(@" SELECT UserRoleId, Description
FROM UserRoles
WHERE Description != 'Admin'
ORDER BY 
  CASE WHEN Description = 'Usuario' THEN 0 ELSE 1 END,
  Description ASC");
        }


    }
}
