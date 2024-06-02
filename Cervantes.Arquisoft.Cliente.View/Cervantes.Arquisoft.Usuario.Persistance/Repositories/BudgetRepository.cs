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
    public class BudgetRepository : IBudgetRepository
    {
    private readonly string connectionString;

    public BudgetRepository(IConfiguration configuration)
    {
        connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }
        public async Task Create(BudgetDTO budgetDto)
        {
            using var conn = new SqlConnection(connectionString);
            var id = await conn.QuerySingleAsync<int>("INSERT INTO BUDGETS VALUES " +
                "(@PROJECTID,@PROJECTTYPEID,@SERVICETYPEID,@CLIENTID,@USERID,@EMISSIONDATE,@DUEDATE,@PROJECTSQUAREMETERS,@COSTPERSQUAREMETERS,@BUDGETDESCRIPTION,@BUDGETSTATEID);" +
                " SELECT SCOPE_IDENTITY();", budgetDto);

            budgetDto.BudgetId = id;
        }

        public async Task Delete(int budgetId)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE Budgets SET @BudgetStateId = 2 WHERE BudgetId = @BudgetId", new { budgetId });
        }

        public async Task<bool> Exist(string projectName)//revisar porque tengo que traer el proyecto para ver si ya tiene presupuesto
        {
            throw new NotImplementedException();
            //using var conn = new SqlConnection(connectionString);
            //bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM Budget 
            //            WHERE BudgetName = @BudgetName) SELECT 1 ELSE SELECT 0", new { BudgetName = projectName });
            //return exists;
        }

        public async Task<IEnumerable<BudgetDTO>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<BudgetDTO>(@"SELECT * FROM Budgets");
        }

        public async Task<BudgetDTO> GetById(int budgetId)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<BudgetDTO>(@"SELECT * FROM Budgets WHERE BudgetId = @budgetId", new { budgetId });
        }

        public Task Update(BudgetDTO budgetDto) // tengo que revisar que necesito actualizar de los presupuestos
        {
            throw new NotImplementedException();
            //using var conn = new SqlConnection(connectionString);
            //await conn.ExecuteAsync(@"UPDATE ServiceType SET ServiceTypeName = @ServiceTypeName, ServiceTypeDescription = @ServiceTypeDescription 
            //                        Where ServiceTypeId = @ServiceTypeId", ServiceTypeDto);
        }
    }
}
