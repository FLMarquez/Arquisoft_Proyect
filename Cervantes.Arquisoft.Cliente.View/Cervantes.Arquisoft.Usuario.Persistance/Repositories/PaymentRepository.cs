using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly string connectionString;

        public PaymentRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Create(PaymentDTO PaymentDTO)
        {
            using var conn = new SqlConnection(connectionString);
            var id = await conn.QuerySingleAsync<int>("INSERT INTO Payments " +
                                                    "(ProjectId, PaymentMethodId, Amount, PaymentDate) " +
                                                    "VALUES (@ProjectId, @PaymentMethodId, @Amount, @PaymentDate); " +
                                                    "SELECT SCOPE_IDENTITY();", PaymentDTO);
            PaymentDTO.PaymentId = id;
        }

        public async Task<IEnumerable<PaymentDTO>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<PaymentDTO>(@"SELECT * FROM Payments");
        }

        public async Task<int> GetLastId()
        {
            using var conn = new SqlConnection(connectionString);
            var proximoId = await conn.ExecuteScalarAsync<int>(@"SELECT IDENT_CURRENT('Payments') + IDENT_INCR('Payments') AS ProximoID;");
            return proximoId;
        }

        public async Task Update(PaymentDTO PaymentDTO)
        {
            using var conn = new SqlConnection(connectionString);
            await conn.ExecuteAsync(@"UPDATE Payments 
                                    SET PaymentId = @PaymentId,
                                        ProjectId = @ProjectId , 
                                        PaymentMethodId = @PaymentMethodId , 
                                        Amount = @Amount,
                                        PaymentDate = @PaymentDate  
                                        Where PaymentId  = @PaymentId ", PaymentDTO);
        }

        public async Task DeleteWithReason(int paymentId, string deletedReason)
        {
            using var conn = new SqlConnection(connectionString);
            try
            {
                await conn.ExecuteAsync(@"
            UPDATE Arquisoft.dbo.Payments
            SET IsDeleted = 1, DeletedReason = @DeletedReason
            WHERE PaymentId = @paymentId;"
                ,
                               new { PaymentId = paymentId, DeletedReason = deletedReason });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al ejecutar la consulta de anulación de page: {ex.Message}");
            }
        }

        public async Task<PaymentDTO> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<PaymentDTO>(@"SELECT * FROM Payments 
                                                                    WHERE PaymentId  = @id", new { id });
        }

        public async Task<string> GetIdPaymentById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<string>(@"SELECT PaymentId  
                                                                   FROM Payments 
                                                                  WHERE PaymentId = @id", new { id });
        }

        public async Task<bool> Exist(int id)
        {
            using var conn = new SqlConnection(connectionString);
            bool exists = await conn.ExecuteScalarAsync<bool>(@"IF EXISTS (SELECT 1 FROM Payments 
                                                                WHERE PaymentIdt = @PaymentIdt) 
                                                                SELECT 1 ELSE SELECT 0", new { PaymentIdt = id });
            return exists;
        }

        public async Task<IEnumerable<PaymentDTO>> GetPaymentByProjectId(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<PaymentDTO>(
                                       @"SELECT 
	                                   PA.*
                                     FROM Payments PA
                                     INNER JOIN Projects P 
                                     ON PA.ProjectId = P.ProjectId
                                     WHERE PA.ProjectId = @id", new { id });
        }


    }
}

