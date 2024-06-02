using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories.Assignment
{
    public interface IAssignmentRepository
    {
        Task Create(AssignmentDTO assignmentDto);
        Task Delete(int id);
        Task<bool> Exist(string name);
        Task<IEnumerable<AssignmentDTO>> GetAllByProjectId(int id);
        Task<AssignmentDTO> GetById(int id);
        Task<IEnumerable<AssignmentDTO>> GetAll();
        Task Update(AssignmentDTO AssignmentDTO);
        Task<AssignmentDTO> UpdateSkippedStatus(int id);
        Task<AssignmentDTO> UpdateCompletionStatus(int id);
        Task<AssignmentDTO> UpdateVisibledStatus(int id);
        Task<IEnumerable<AssignmentDTO>> GetAllByClientId(int id);
        Task<AssignmentDTO> GetAssignmentStatus(int id);
        Task UpdateTitleDesc(AssignmentDTO AssignmentDTO);
    }

    public class AssignmentRepository : IAssignmentRepository
    {

        private readonly string connectionString;

        public AssignmentRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }


        public async Task Create(AssignmentDTO assignmentDto)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);

                var id = await conn.QuerySingleAsync<int>(
                    "INSERT INTO Assignments (AssignmentName, AssignmentDescription, Order, ServiceTypeId)" +
                    "VALUES (@AssignmentName, @AssignmentDescription, @Order, @ServiceTypeId); SELECT SCOPE_IDENTITY();",
                    assignmentDto);

                assignmentDto.AssignmentId = id;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de creación de Assignment: " + ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.ExecuteAsync(@"DELETE FROM Assignments WHERE AssignmentId = @id", new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de eliminación de Assignment: " + ex.Message);
            }
        }

        public async Task<bool> Exist(string name)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM Assignments
                    WHERE AssignmentName = @AssignmentName) SELECT 1 ELSE SELECT 0", new { AssignmentName = name });
                return exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al verificar la existencia de Assignment: " + ex.Message);
                return false;
            }
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAllByProjectId(int id)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryAsync<AssignmentDTO>(@"SELECT Assignments.* FROM Assignments 
                                                    INNER JOIN AssignmentsTypes ON Assignments.AssignmentTypeId = AssignmentsTypes.AssignmentTypeId
                                                    WHERE ProjectId = @id ORDER BY [Order];", new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener todas las asignaciones por ID de proyecto: " + ex.Message);
                return Enumerable.Empty<AssignmentDTO>();
            }
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAllByClientId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<AssignmentDTO>(@"SELECT a.* FROM Assignments a 
                   INNER JOIN AssignmentsTypes t ON a.AssignmentTypeId = t.AssignmentTypeId
                   INNER JOIN Projects p ON a.ProjectId = p.ProjectId WHERE ClientId = @id", new { id });
        }

        public async Task<IEnumerable<AssignmentDTO>> GetAll()
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryAsync<AssignmentDTO>(@"
        SELECT * FROM Assignments;");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener todas las asignaciones: " + ex.Message);
                return Enumerable.Empty<AssignmentDTO>();
            }
        }

        public async Task<AssignmentDTO> GetById(int id)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryFirstOrDefaultAsync<AssignmentDTO>(@"SELECT * FROM Assignments WHERE AssignmentId = @id", new { id });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener la asignación por ID: " + ex.Message);
                return null;
            }
        }


        public async Task<AssignmentDTO> UpdateCompletionStatus(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var transaction = conn.BeginTransaction();

            try
            {
                try
                {
                    var currentStatus = await conn.QueryFirstOrDefaultAsync<(bool IsCompleted, DateTime? CompletedDate)>(
                        "SELECT IsCompleted, CompletedDate FROM Assignments WHERE AssignmentId = @id", new { id }, transaction);

                    DateTime? completedDate = null;

                    // Si se establece IsCompleted en true, asigna la fecha actual a completedDate
                    if (!currentStatus.IsCompleted)
                    {
                        completedDate = DateTime.Now;
                    }

                    await conn.ExecuteAsync(@"UPDATE Assignments
                                            SET IsCompleted = CASE 
                                                WHEN IsCompleted = 1 THEN 0  
                                                WHEN IsCompleted = 0 THEN 1  
                                            END,
                                            CompletedDate = CASE 
                                                WHEN IsCompleted = 1 THEN NULL 
                                                WHEN IsCompleted = 0 THEN CONVERT(date, @currentDate, 5)  
                                            END
                                            WHERE AssignmentId = @id;", new { id, currentDate = DateTime.Now.ToString("dd-MM-yy") }, transaction);
                    transaction.Commit();

                    var newStatus = new AssignmentDTO
                    {
                        AssignmentId = id,
                        IsCompleted = !currentStatus.IsCompleted,
                        CompletedDate = completedDate // Incluye la fecha en el DTO
                    };
                    return newStatus;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public async Task<AssignmentDTO> UpdateSkippedStatus(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var transaction = conn.BeginTransaction();

            try
            {
                var currentStatus = await conn.QueryFirstOrDefaultAsync<(bool IsSkipped, DateTime? SkippedDate)>(
                    "SELECT IsSkipped, SkippedDate FROM Assignments WHERE AssignmentId = @id", new { id }, transaction);

                DateTime? skippedDate = null;

                // Si se establece IsSkipped en true, asigna la fecha actual a skippedDate
                if (!currentStatus.IsSkipped)
                {
                    skippedDate = DateTime.Now;
                }

                await conn.ExecuteAsync(@"UPDATE Assignments
                                            SET IsSkipped = CASE 
                                                WHEN IsSkipped = 1 THEN 0  
                                                WHEN IsSkipped = 0 THEN 1  
                                            END,
                                            SkippedDate = CASE 
                                                WHEN IsSkipped = 0 THEN CONVERT(date, @currentDate, 5)  
                                                WHEN IsSkipped = 1 THEN NULL 
                                            END
                                            WHERE AssignmentId = @id;", new { id, currentDate = DateTime.Now.ToString("dd-MM-yy") }, transaction);
                transaction.Commit();

                var newStatus = new AssignmentDTO
                {
                    AssignmentId = id,
                    IsSkipped = !currentStatus.IsSkipped,
                    SkippedDate = skippedDate // Incluye la fecha en el DTO
                };

                return newStatus;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public async Task<AssignmentDTO> UpdateVisibledStatus(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            var transaction = conn.BeginTransaction();

            try
            {
                var currentStatus = await conn.ExecuteScalarAsync<bool>(
                    "SELECT NotVisible FROM Assignments WHERE AssignmentId = @id", new { id }, transaction);
                await conn.ExecuteAsync(@"UPDATE Assignments
                                        SET NotVisible = CASE 
                                            WHEN NotVisible = 1 THEN 0  
                                            WHEN NotVisible = 0 THEN 1  
                                        END
                                        WHERE AssignmentId = @id;", new { id }, transaction);
                transaction.Commit();

                var newStatus = new AssignmentDTO
                {
                    AssignmentId = id,
                    NotVisible = !currentStatus
                };
                return newStatus;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }


        public async Task<AssignmentDTO> GetAssignmentStatus(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();

            // Consultar el estado actual de la tarea
            var currentStatus = await conn.QueryFirstOrDefaultAsync<AssignmentDTO>(
                "SELECT IsCompleted, IsSkipped FROM Assignments WHERE AssignmentId = @id", new { id });

            return currentStatus;
        }

        public async Task Update(AssignmentDTO AssignmentDTO)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.ExecuteAsync(@"UPDATE Arquisoft.dbo.Assignments
                                          SET
                                            ProjectId = @ProjectId,
                                            AssignmentTypeId = @AssignmentTypeId,
                                            AssignmentName = @AssignmentName,
                                            AssignmentDescription = @AssignmentDescription,
                                            IsCompleted = @IsCompleted,
                                            NotVisible = @NotVisible,
                                            IsStarted = @IsStarted,
                                            IsSkipped = @IsSkipped,
                                            CompletedDate=@CompletedDate, 
	                                        StartedDate=@StartedDate, 
	                                        SkippedDate=@SkippedDate,
                                            OriginalDueDate=@OriginalDueDate
                                        WHERE AssignmentId = @AssignmentId
                                        ", AssignmentDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de edición de Assignment: " + ex.Message);
            }


        }

        public async Task UpdateTitleDesc(AssignmentDTO AssignmentDTO)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.ExecuteAsync(@"UPDATE Arquisoft.dbo.Assignments
                                          SET
                                            AssignmentName = @AssignmentName,
                                            AssignmentDescription = @AssignmentDescription
                                        WHERE AssignmentId = @AssignmentId
                                        ", AssignmentDTO);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de edición de Assignment: " + ex.Message);
            }


        }
    }
}
