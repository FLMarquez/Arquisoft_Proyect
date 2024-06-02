using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories.Project
{
    public interface IHistoricalProjectRepository
    {
        Task InsertHistorical(ProjectDto p);
    }

    public class HistoricalProjectRepository : IHistoricalProjectRepository
    {

        private readonly string connectionString;

        public HistoricalProjectRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task InsertHistorical(ProjectDto p)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"INSERT INTO Arquisoft.dbo.HistoricalProjects
                                            (ProjectId, HistoricalDate, StateId, ProjectTypeId)
                                            VALUES(@projectId, GETDATE(), @stateId, @projectTypeId);",
                                            new
                                            {
                                                projectId = p.ProjectId,
                                                stateId = p.ProjectStateId,
                                                projectTypeId = p.ProjectTypeId
                                            });
        }
    }
}
