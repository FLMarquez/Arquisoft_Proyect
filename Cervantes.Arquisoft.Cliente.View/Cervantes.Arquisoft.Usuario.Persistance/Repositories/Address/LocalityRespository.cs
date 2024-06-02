using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface ILocalityRepository
    {
        Task<IEnumerable<LocalityDto>> GetAll();
        Task<IEnumerable<LocalityDto>> GetByProvinceId(int provinceId);
    }
    public class LocalityRepository : ILocalityRepository
    {
        private readonly string connectionString;

        public LocalityRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<IEnumerable<LocalityDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<LocalityDto>(@"SELECT * FROM Localities ORDER BY Description ASC;");
        }

        public async Task<IEnumerable<LocalityDto>> GetByProvinceId(int provinceId)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<LocalityDto>(@"SELECT * FROM Localities WHERE ProvinceId = @provinceId ORDER BY Description ASC", new { provinceId });
        }

    }


}
