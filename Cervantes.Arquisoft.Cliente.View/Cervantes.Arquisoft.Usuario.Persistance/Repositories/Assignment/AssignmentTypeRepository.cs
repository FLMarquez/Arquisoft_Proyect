using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories.Assignment
{
    public interface IAssignmentTypeRepository
    {
        Task Create(AssignmentType AssignmentTypeDTO);
        Task Delete(int id);
        Task<bool> Exist(string name);
        Task<IEnumerable<AssignmentTypeDTO>> GetAllByServiceId(int id);
        Task<AssignmentTypeDTO> GetById(int id);
        Task Sorter(IEnumerable<AssignmentTypeDTO> AssignmentTypeSorted);
        Task Update(AssignmentTypeDTO assignmentTypeDTO);
    }

    public class AssignmentTypeRepository : IAssignmentTypeRepository
    {

        private readonly string connectionString;

        public AssignmentTypeRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task Create(AssignmentType AssignmentTypeDTO)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);

                // Traer el valor de 'Order' antes de la inserción
                int order = await conn.QuerySingleOrDefaultAsync<int>(
                    "SELECT COALESCE(MAX([Order]), 0) + 1 FROM AssignmentsTypes WHERE ServiceTypeId = @ServiceTypeId",
                    new { AssignmentTypeDTO.ServiceTypeId });

                // Asignar el valor de 'Order' a la propiedad correspondiente en AssignmentTypeDTO
                AssignmentTypeDTO.Order = order;

                // Realizar la inserción en la base de datos
                var id = await conn.QuerySingleAsync<int>(
                    "INSERT INTO AssignmentsTypes (AssignmentTypeName, AssignmentTypeDescription, [Order], ServiceTypeId)" +
                    "VALUES (@AssignmentTypeName, @AssignmentTypeDescription, @Order, @ServiceTypeId); SELECT SCOPE_IDENTITY();",
                    AssignmentTypeDTO);

                AssignmentTypeDTO.AssignmentTypeId = id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la inserción del Create: " + ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"DELETE FROM AssignmentsTypes WHERE AssignmentTypeId = @id", new { id });
        }

        public async Task<bool> Exist(string name)
        {
            using var conn = new SqlConnection(connectionString);
            bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM AssignmentsTypes 
                        WHERE AssignmentTypeName = @AssignmentTypeName) SELECT 1 ELSE SELECT 0", new { AssignmentTypeName = name });
            return exists;
        }

        public async Task<IEnumerable<AssignmentTypeDTO>> GetAllByServiceId(int id)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryAsync<AssignmentTypeDTO>(@"SELECT * FROM AssignmentsTypes WHERE ServiceTypeId = @id ORDER BY [Order]", new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta GetAllByService: " + ex.Message);
            }
            return null;
        }

        public async Task<AssignmentTypeDTO> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<AssignmentTypeDTO>(@"SELECT * FROM AssignmentsTypes WHERE AssignmentTypeId = @id", new { id });

        }

        public async Task Update(AssignmentTypeDTO AssignmentTypeDTO)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE AssignmentsTypes SET AssignmentTypeName = @AssignmentTypeName, AssignmentTypeDescription = @AssignmentTypeDescription, ServiceTypeId=@ServiceTypeId
                                    Where AssignmentTypeId = @AssignmentTypeId", AssignmentTypeDTO);
        }

        public async Task Sorter(IEnumerable<AssignmentTypeDTO> AssignmentTypeSorted)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                var query = "UPDATE AssignmentsTypes SET [Order] = @Order Where AssignmentTypeId = @AssignmentTypeId;";
                await conn.ExecuteAsync(query, AssignmentTypeSorted);
                Console.WriteLine(query);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la inserción: " + ex.Message);
            }
        }
    }


}
