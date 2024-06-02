using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class ClientDashboardRepository : IClientDashboardRepository
    {
        private readonly string connectionString;

        public ClientDashboardRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<ClientDashboardDTO>> GetAllClientDashboard(int clientId)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryAsync<ClientDashboardDTO>(
                    @"
                     SELECT
	                    p.ProjectId AS ProjectId,
	                    p.Name AS ProjectName,
	                    c.Name + ', ' + c.LastName AS ClientName,
	                    ProjectTypes.ProjectTypeName AS ProjectTypeName,
	                    u.Name + ', ' + u.LastName AS UserName,
	                    a.AssignmentId, a.AssignmentName, a.AssignmentDescription, a.IsCompleted, a.IsStarted, a.IsSkipped, a.CompletedDate, a.StartedDate, a.SkippedDate, a.OriginalDueDate, a.IsDeleted,
	                    h.HubId, h.HubDate, h.IsCommitment, h.DueDate, h.Note, h.UserName, h.IsAttachment, h.FileName, h.FileDescription, h.ContentType, h.Base64File, h.IsDeleted
                    FROM
	                    Projects p
                    INNER JOIN Users u ON
	                    p.UserId = u.UserId
                    INNER JOIN ProjectTypes ON
	                    p.ProjectTypeId = ProjectTypes.ProjectTypeId
                    INNER JOIN ProjectState ON
	                    p.ProjectStateId = ProjectState.ProjectStateId
                    INNER JOIN Clients c ON
	                    p.ClientId = c.ClientId
                    INNER JOIN Assignments a ON
	                    a.ProjectId = p.ProjectId
                    INNER JOIN Hub h ON
	                    a.AssignmentId = h.AssignmentId
                    WHERE
	                    p.ProjectStateId = 1 and a.NotVisible = 1 and
                                    c.ClientId = @ClientId
            ", new { ClientId = clientId }



                );
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta GetAllProjectWithDetails: " + ex.Message);
                throw; // Asegúrate de propagar la excepción para manejarla en un nivel superior si es necesario
            }
        }
    }
}

