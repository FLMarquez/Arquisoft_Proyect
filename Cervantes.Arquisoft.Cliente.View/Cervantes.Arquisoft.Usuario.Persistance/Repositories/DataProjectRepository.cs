using Cervantes.Arquisoft.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface IDataProjectRepository
    {
        Task<IEnumerable<Amount_Method>> GetAmount_Method();
        Task<IEnumerable<Amount_Time>> GetAmount_Time();
        Task<IEnumerable<DataProjectStateDTO>> GetProjectStateData();
        Task<IEnumerable<DataProjectTypeDTO>> GetProjectTypeData();
        Task<IEnumerable<ProjectType_Amount>> GetProjectType_Amount();
    }
    public class DataProjectRepository : IDataProjectRepository
    {
        private readonly string connectionString;

        public DataProjectRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<DataProjectStateDTO>> GetProjectStateData()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<DataProjectStateDTO>(
                @"SELECT ps.Description as Status, FORMAT(hp.HistoricalDate, 'MM/yyyy') as Date, hp.ProjectId as ProjectId 
FROM HistoricalProjects hp
INNER JOIN ProjectState ps ON ps.ProjectStateId = hp.StateId;
");
        }

        public async Task<IEnumerable<DataProjectTypeDTO>> GetProjectTypeData()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<DataProjectTypeDTO>(
                @"SELECT DATEADD(MONTH, DATEDIFF(MONTH, 0, hp.HistoricalDate), 0) as Date,
                  pt.ProjectTypeName as Type
                  FROM HistoricalProjects hp
                  INNER JOIN ProjectTypes pt ON pt.ProjectTypeId = hp.ProjectTypeId
                  GROUP BY DATEADD(MONTH, DATEDIFF(MONTH, 0, hp.HistoricalDate), 0), hp.ProjectTypeId, pt.ProjectTypeName;");
        }


        public async Task<IEnumerable<Amount_Method>> GetAmount_Method()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Amount_Method>(
                @" SELECT pm.MethodName  , SUM(p.Amount) AS Amount
                FROM Payments p
                INNER JOIN PaymentMethods pm ON pm.PaymentMethodId = p.PaymentMethodId  
                WHERE p.IsDeleted IS NULL OR p.IsDeleted = 0
               	GROUP BY pm.MethodName;");
        }

        public async Task<IEnumerable<ProjectType_Amount>> GetProjectType_Amount()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<ProjectType_Amount>(
                @"SELECT SUM(py.Amount) AS Amount, pt.ProjectTypeDescription 
                FROM Payments py
                INNER JOIN Projects p on py.ProjectId = p.ProjectId
                INNER JOIN ProjectTypes pt on pt.ProjectTypeId = p.ProjectTypeId 
                WHERE py.IsDeleted IS NULL OR py.IsDeleted = 0
                GROUP BY pt.ProjectTypeDescription ; ");
        }


        public async Task<IEnumerable<Amount_Time>> GetAmount_Time()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<Amount_Time>(
                @"SELECT FORMAT(p.PaymentDate, 'MM/yyyy') as Date, p.Amount as Amount
                    FROM Payments p
                    WHERE p.IsDeleted IS NULL OR p.IsDeleted = 0;");
        }
    }
}
