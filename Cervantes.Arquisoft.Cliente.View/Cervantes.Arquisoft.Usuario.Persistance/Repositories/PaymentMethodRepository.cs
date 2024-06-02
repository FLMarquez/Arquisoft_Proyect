using Cervantes.Arquisoft.Application.DTOs.Budget;
using Cervantes.Arquisoft.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class PaymentMethodRepository : IPaymentMethodRepository
    {

        private readonly string connectionString;

        public PaymentMethodRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }


        public async Task<IEnumerable<PaymentMethodDTO>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<PaymentMethodDTO>(@"SELECT * FROM PaymentMethods");
        }

        public async Task<PaymentMethodDTO> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<PaymentMethodDTO>(@"SELECT * FROM PaymentMethods 
                                                                    WHERE PaymentMethodId  = @id", new { id });
        }

        public async Task<PaymentMethodDTO> GetByProjectId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<PaymentMethodDTO>(@"SELECT PM.PaymentMethodId, PM.MethodName, 
                                                                                    PR.ProjectId,P.ProjectId 
                                                                            FROM           
                                                                            dbo.PaymentMethods  PM
                                                                            INNER JOIN dbo.Payments P ON P.PaymentMethodId = PM.PaymentMethodId
                                                                            INNER JOIN  dbo.Projects PR ON P.ProjectId = @id", new { id });
        }

        public async Task<PaymentMethodDTO> GetMethodByPaymentId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<PaymentMethodDTO>(@"SELECT PM.MethodName
                                                                              FROM PaymentMethods PM 
                                                                            INNER JOIN Payments P ON  PM.PaymentMethodId = P.PaymentMethodId
                                                                             WHERE P.PaymentId = @id", new { id });
        }
    }
}
