using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories.Assignment
{
    public interface IHubRepository
    {
        Task CreateFirst(DateTime originalDueDate, int id, int userId, string Username);

        Task CreateWithAttachment(HubDto hub);
        Task<IEnumerable<HubDto>> GetAllHubByAssigmentId(int id);
        Task<(byte[], string, string)> GetAttachmentData(int hubId);
        Task<IEnumerable<HubDto>> GetAllByClientId(int id);
        Task<IEnumerable<HubDto>> GetAllByProjectId(int id);
        Task DeleteWithReason(int hubId, string deletedReason);
    }

    public class PaymentRepository : IHubRepository
    {
        private readonly string connectionString;

        public PaymentRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public async Task<IEnumerable<HubDto>> GetAllHubByAssigmentId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<HubDto>(@"
                        SELECT HubId, AssignmentId, HubDate, IsCommitment, DueDate, Note, UserId, UserName, IsAttachment, FileName, FileDescription, ContentType, IsDeleted, DeletedReason
                        FROM Arquisoft.dbo.Hub WHERE AssignmentId = @AssignmentId
                        ORDER BY HubDate DESC;
                                                ", new { AssignmentId = id });
        }
        public async Task CreateFirst(DateTime originalDueDate, int id, int userId, string Username)
        {
            using var conn = new SqlConnection(connectionString);
            try
            {
                await conn.ExecuteAsync(@"
            INSERT INTO Arquisoft.dbo.Hub
            (AssignmentId, DueDate, HubDate, Note, UserId, UserName, IsCommitment, IsAttachment )
            VALUES (@AssignmentId, @OriginalDueDate,GETDATE(), 'Tarea Iniciada. Primer Compromiso', @UserId, @UserName, 1, 0);",
                     new { AssignmentId = id, OriginalDueDate = originalDueDate, UserId = userId, UserName = Username });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta de inserción de Commitment: {ex.Message}");
            }
        }
        public async Task CreateWithAttachment(HubDto hub)
        {
            using var conn = new SqlConnection(connectionString);
            try
            {
                await conn.ExecuteAsync(@"
            INSERT INTO Arquisoft.dbo.Hub
            (AssignmentId, DueDate, HubDate, Note, UserId, UserName, IsAttachment, IsCommitment, FileName, FileDescription, AttachmentData, IsDeleted)
            VALUES (@AssignmentId, @DueDate, GETDATE(), @Note, @UserId, @UserName, @IsAttachment, @IsCommitment, @FileName, @FileDescription, @AttachmentData, @IsDeleted);",
                    new
                    {
                        hub.AssignmentId,
                        DueDate = hub.DueDate ?? (object)DBNull.Value,
                        hub.Note,
                        UserId = hub.UserId == 0 ? (object)DBNull.Value : hub.UserId,
                        UserName = string.IsNullOrEmpty(hub.UserName) ? (object)DBNull.Value : hub.UserName,
                        hub.IsAttachment,
                        hub.IsCommitment,
                        FileName = string.IsNullOrEmpty(hub.FileName) ? (object)DBNull.Value : hub.FileName,
                        FileDescription = string.IsNullOrEmpty(hub.FileDescription) ? (object)DBNull.Value : hub.FileDescription,
                        AttachmentData = hub.AttachmentData, // Asegúrate de que AttachmentData sea de tipo byte[]
                        IsDeleted = hub.IsDeleted ?? false
                    });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta de inserción con Archivo Adjunto: {ex.Message}");
                // Manejar la excepción según sea necesario
            }
        }

        public async Task<IEnumerable<HubDto>> GetAllByProjectId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<HubDto>(@"
                        SELECT        dbo.Clients.ClientId, dbo.Hub.HubId, dbo.Hub.AssignmentId, dbo.Hub.HubDate, dbo.Hub.IsCommitment, dbo.Hub.DueDate, dbo.Hub.Note, dbo.Hub.UserId, dbo.Hub.UserName, dbo.Hub.IsAttachment, dbo.Hub.FileName, 
                         dbo.Hub.FileDescription, dbo.Hub.ContentType, dbo.Hub.IsDeleted, dbo.Hub.DeletedReason, dbo.Hub.AttachmentData 
FROM            dbo.Clients INNER JOIN
                         dbo.Projects ON dbo.Clients.ClientId = dbo.Projects.ClientId INNER JOIN
                         dbo.Assignments ON dbo.Projects.ProjectId = dbo.Assignments.ProjectId INNER JOIN
                         dbo.Hub ON dbo.Assignments.AssignmentId = dbo.Hub.AssignmentId
				  WHERE Projects.ProjectId = @ProjectId;
                                                ", new { ProjectId = id });
        }

        public async Task<IEnumerable<HubDto>> GetAllByClientId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<HubDto>(@"
                        SELECT        dbo.Clients.ClientId, dbo.Hub.HubId, dbo.Hub.AssignmentId, dbo.Hub.HubDate, dbo.Hub.IsCommitment, dbo.Hub.DueDate, dbo.Hub.Note, dbo.Hub.UserId, dbo.Hub.UserName, dbo.Hub.IsAttachment, dbo.Hub.FileName, 
                         dbo.Hub.FileDescription, dbo.Hub.ContentType, dbo.Hub.IsDeleted, dbo.Hub.DeletedReason, dbo.Hub.AttachmentData
FROM            dbo.Clients INNER JOIN
                         dbo.Projects ON dbo.Clients.ClientId = dbo.Projects.ClientId INNER JOIN
                         dbo.Assignments ON dbo.Projects.ProjectId = dbo.Assignments.ProjectId INNER JOIN
                         dbo.Hub ON dbo.Assignments.AssignmentId = dbo.Hub.AssignmentId
				  WHERE Projects.ClientId = @ClientId;
                                                ", new { ClientId = id });
        }

        public async Task<(byte[], string, string)> GetAttachmentData(int hubId)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                // Consulta para obtener los datos del archivo adjunto, su nombre y tipo de archivo
                var result = await conn.QueryFirstOrDefaultAsync<(byte[], string, string)>(@"
            SELECT AttachmentData, FileName, ContentType
            FROM Arquisoft.dbo.Hub
            WHERE HubId = @HubId", new { HubId = hubId });

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener datos de archivo adjunto: {ex.Message}");
                return (null, null, null);
            }
        }

        public async Task DeleteWithReason(int hubId, string deletedReason)
        {
            using var conn = new SqlConnection(connectionString);
            try
            {
                await conn.ExecuteAsync(@"
            UPDATE Arquisoft.dbo.Hub
            SET IsDeleted = 1, DeletedReason = @DeletedReason
            WHERE HubId = @HubId;",
                               new { HubId = hubId, DeletedReason = deletedReason });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta de anulación de compromiso: {ex.Message}");
                // Manejar la excepción según sea necesario
            }
        }



    }

}

