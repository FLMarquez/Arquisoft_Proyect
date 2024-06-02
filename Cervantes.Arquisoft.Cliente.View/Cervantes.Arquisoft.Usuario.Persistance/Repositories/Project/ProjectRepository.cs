using Cervantes.Arquisoft.Application.DTOs;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface IProjectRepository
    {
        Task Create(ProjectDto projectDto);
        Task Delete(int id);
        Task<IEnumerable<ProjectDto>> GetAll();
        Task<ProjectDto> GetById(int id);
        Task Update(ProjectDto projectDto);

        Task<bool> Exist(string name);

        Task<IEnumerable<ProjectWithDetailDTO>> GetAllProjectWithDetails();

        Task<IEnumerable<ProjectWithDetailDTO>> GetProjectByUserId(int userId);

        Task<string> GetProjectNameById(int id);
        Task<IEnumerable<ProjectDto>> GetProjectsByClientId(int id);
    }
    public class ProjectRepository : IProjectRepository
    {

        private readonly string connectionString;

        public ProjectRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Create(ProjectDto project)
        {
            project.ProjectStateId = 1;
            using var conn = new SqlConnection(connectionString);
            try
            {
                var id = await conn.QuerySingleAsync<int>("INSERT INTO Projects (Name, UserId, ClientId, ProjectTypeId, ProjectStateId, ServiceTypeId, Budget) " +
                "VALUES (@Name, @UserId, @ClientId, @ProjectTypeId, @ProjectStateId, @ServiceTypeId, @Budget); SELECT SCOPE_IDENTITY();", project);

                project.ProjectId = id;

                // Insertar registros en la tabla Assignments
                var assignmentQuery = @"
            INSERT INTO Assignments (ProjectId, AssignmentTypeId, AssignmentName, AssignmentDescription, IsCompleted, NotVisible, IsStarted, IsSkipped, StartedDate)
            SELECT @ProjectId, AssignmentTypeId, AssignmentTypeName, AssignmentTypeDescription, 0, 0, 0, 0, GETDATE()
            FROM AssignmentsTypes
            WHERE ServiceTypeId = @ServiceTypeId
            ";

                await conn.ExecuteAsync(assignmentQuery, new { ProjectId = project.ProjectId, ServiceTypeId = project.ServiceTypeId });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de inserción de la creación de proyecto: " + ex.Message);
            }
        }

        public async Task<bool> Exist(string name)
        {
            using var conn = new SqlConnection(connectionString);
            bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM Projects WHERE Name = @Name) SELECT 1 ELSE SELECT 0", new { Name = name });
            return exists;
        }

        public async Task<IEnumerable<ProjectDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProjectDto>(@"SELECT * FROM Projects ORDER BY Name;");
        }

        public async Task Update(ProjectDto projectDto)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE Projects SET Name = @Name, 
                                                          ClientId = @ClientId,
                                                          UserId = @UserId,
                                                          ProjectTypeId = @ProjectTypeId,
                                                          ProjectStateId = @ProjectStateId,
                                                          Budget = @Budget
                                                          Where ProjectId = @ProjectId
                                    ", projectDto);
        }
        public async Task Delete(int id)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE PROJECTS SET PROJECTSTATEID = 2 WHERE PROJECTID = @id", new { id });
        }
        public async Task<ProjectDto> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<ProjectDto>(@"SELECT * FROM Projects WHERE ProjectId = @id", new { id });
        }

        public async Task<IEnumerable<ProjectWithDetailDTO>> GetAllProjectWithDetails()
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                return await conn.QueryAsync<ProjectWithDetailDTO>(
                    @"
                       SELECT 
                        Projects.ProjectId
                        , Projects.Name AS ProjectName -- Esto es requerido para que se inserte correctamente en el dto
                        , Users.UserId 
                        , Users.Name AS UserName -- Esto es requerido para que se inserte correctamente en el dto
                        , Users.LastName AS UserLastName -- Esto es requerido para que se inserte correctamente en el dto
                        , Clients.ClientId 
                        , Clients.Name AS ClientName -- Esto es requerido para que se inserte correctamente en el dto
                        , Clients.LastName AS ClientLastName -- Esto es requerido para que se inserte correctamente en el dto
                        , ProjectTypes.ProjectTypeId 
                        , ProjectTypes.ProjectTypeName
                        , ProjectState.ProjectStateId 
                        , ProjectState.Description
                        FROM Clients 
                        INNER JOIN Projects ON Clients.ClientId = Projects.ClientId 
                        INNER JOIN Users ON Projects.UserId = Users.UserId 
                        LEFT JOIN ProjectTypes ON Projects.ProjectTypeId = ProjectTypes.ProjectTypeId 
                        INNER JOIN ProjectState ON Projects.ProjectStateId = ProjectState.ProjectStateId
                        WHERE ProjectState.ProjectStateId != 2
                        ORDER BY Projects.Name;
                        ");
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error al ejecutar la consulta GetAllProjectWithDetails: " + ex.Message);

            }
            return null;
            ;

        }
        public async Task<IEnumerable<ProjectDto>> GetProjectsByClientId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProjectDto>(@"SELECT * from Projects WHERE ClientId = @id", new { id });
        }


        public async Task<IEnumerable<ProjectWithDetailDTO>> GetProjectByUserId(int userId)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProjectWithDetailDTO>(@"
            SELECT dbo.Projects.ProjectId, dbo.Projects.Name, dbo.Clients.Name AS Expr1, dbo.Clients.LastName, dbo.Users.Name AS Expr2, dbo.Users.LastName AS Expr3, dbo.ProjectTypes.ProjectTypeName, dbo.ProjectState.Description, 
                   dbo.Users.UserId
            FROM   dbo.Projects INNER JOIN
                   dbo.Users ON dbo.Projects.UserId = dbo.Users.UserId INNER JOIN
                   dbo.Clients ON dbo.Projects.ClientId = dbo.Clients.ClientId INNER JOIN
                   dbo.ProjectTypes ON dbo.Projects.ProjectTypeId = dbo.ProjectTypes.ProjectTypeId INNER JOIN
                   dbo.ProjectState ON dbo.Projects.ProjectStateId = dbo.ProjectState.ProjectStateId
            WHERE dbo.Users.UserId = @userId
", new
            {
                userId
            });
        }

        public async Task<string> GetProjectNameById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<string>(@"SELECT Name FROM Projects WHERE ProjectId = @id", new { id });
        }
    }
}
