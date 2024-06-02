using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class ProjectStateRepository : IProjectStateRepository
    {

        private readonly string connectionString;

        public ProjectStateRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Create(ProjectStateDto projectStateDto)
        {
            using var conn = new SqlConnection(connectionString);
            var id = await conn.QuerySingleAsync<int>("INSERT INTO ProjectState VALUES (@Description); SELECT SCOPE_IDENTITY();", projectStateDto);

            projectStateDto.ProjectStateId = id;
        }

        public Task Delete(int dni)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(int dni)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProjectStateDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProjectStateDto>(@"SELECT * FROM ProjectState");
        }

        public async Task<ProjectStateDto> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<ProjectStateDto>(@"SELECT * FROM ProjectState WHERE ProjectStateId = @id", new { id });
        }

        public async Task Update(ProjectStateDto projectStateDto)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE ProjectState SET Description = @Description where ProjectStateId = @id", projectStateDto);
        }
    }
}
