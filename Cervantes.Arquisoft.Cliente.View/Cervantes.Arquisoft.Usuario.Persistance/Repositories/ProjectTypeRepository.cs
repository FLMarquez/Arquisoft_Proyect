using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class ProjectTypeRepository : IProjectTypeRepository
    {

        private readonly string connectionString;

        public ProjectTypeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task Create(ProjectType projectTypeDTO)
        {
            using var conn = new SqlConnection(connectionString);

            // No incluir ProjectTypeId en la lista de columnas a insertar
            var id = await conn.QuerySingleAsync<int>(
                "INSERT INTO ProjectTypes (ProjectTypeName, ProjectTypeDescription, RangeMax, RangeMin, ProfessionalFee)" +
                "VALUES (@ProjectTypeName, @ProjectTypeDescription, @RangeMax, @RangeMin, @ProfessionalFee); SELECT SCOPE_IDENTITY();",
                projectTypeDTO);

            projectTypeDTO.ProjectTypeId = id;
        }

        public async Task Delete(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE ProjectTypes SET IsDeleted = 1 WHERE ProjectTypeId = @id", new { id });
        }

        public async Task<bool> Exist(string name)
        {
            using var conn = new SqlConnection(connectionString);
            bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM ProjectTypes 
                        WHERE ProjectTypeName = @ProjectTypeName) SELECT 1 ELSE SELECT 0", new { ProjectTypeName = name });
            return exists;
        }

        public async Task<IEnumerable<ProjectTypeDTO>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProjectTypeDTO>(@"SELECT * FROM ProjectTypes WHERE IsDeleted = 0 ORDER BY ProjectTypeName ASC");
        }

        public async Task<ProjectTypeDTO> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<ProjectTypeDTO>(@"SELECT * FROM ProjectTypes WHERE ProjectTypeId = @id", new { id });
        }

        public async Task Update(ProjectType projectTypeDTO)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE ProjectTypes SET ProjectTypeName = @ProjectTypeName, ProjectTypeDescription = @ProjectTypeDescription, RangeMax=@RangeMax,RangeMin=@RangeMin,ProfessionalFee=@ProfessionalFee
                                    Where ProjectTypeId = @ProjectTypeId", projectTypeDTO);
        }
    }
}

