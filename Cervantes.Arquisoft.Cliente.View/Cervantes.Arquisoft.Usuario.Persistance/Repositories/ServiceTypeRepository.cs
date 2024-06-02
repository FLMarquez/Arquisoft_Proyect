using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class ServiceTypeRepository : IServiceTypeRepository
    {

        private readonly string connectionString;

        public ServiceTypeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Create(ServiceTypeDto ServiceTypeDto)
        {
            using var conn = new SqlConnection(connectionString);
            var id = await conn.QuerySingleAsync<int>("INSERT INTO ServiceTypes (ServiceTypeName, ServiceTypeDescription) VALUES(@ServiceTypeName, @ServiceTypeDescription); SELECT SCOPE_IDENTITY();",
                new { ServiceTypeName = ServiceTypeDto.ServiceTypeName, ServiceTypeDescription = ServiceTypeDto.ServiceTypeDescription });

            ServiceTypeDto.ServiceTypeId = id;
        }

        public async Task<bool> Exist(string name)
        {
            using var conn = new SqlConnection(connectionString);
            bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM ServiceTypes
                        WHERE ServiceTypeName = @ServiceTypeName) SELECT 1 ELSE SELECT 0", new { ServiceTypeName = name });
            return exists;
        }

        public async Task<IEnumerable<ServiceTypeDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ServiceTypeDto>(@"SELECT * FROM ServiceTypes ORDER BY ServiceTypeName ASC");
        }

        public async Task Update(ServiceTypeDto ServiceTypeDto)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE ServiceTypes SET ServiceTypeName = @ServiceTypeName, ServiceTypeDescription = @ServiceTypeDescription 
                                    Where ServiceTypeId = @ServiceTypeId", ServiceTypeDto);
        }
        public async Task Delete(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"DELETE FROM ServiceTypes WHERE ServiceTypeId = @id", new { id });
        }
        public async Task<ServiceTypeDto> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<ServiceTypeDto>(@"SELECT * FROM ServiceTypes WHERE ServiceTypeId = @id", new { id });
        }

        public async Task<string> GetServiceTypeNameById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<string>(@"SELECT ServiceTypeName FROM ServiceTypes WHERE ServiceTypeId = @id", new { id });
        }
    }
}