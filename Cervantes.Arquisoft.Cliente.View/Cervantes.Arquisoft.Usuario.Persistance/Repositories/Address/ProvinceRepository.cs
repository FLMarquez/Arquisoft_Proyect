using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface IProvinceRepository
    {
        Task<IEnumerable<ProvinceDto>> GetAll();
    }
    public class ProvinceRepository : IProvinceRepository
    {
        private readonly string connectionString;

        public ProvinceRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<IEnumerable<ProvinceDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProvinceDto>(@"SELECT * FROM Provinces");
        }
    }


}
