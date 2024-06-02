using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface IAuditableRepository
    {
        Task<bool> UpdateAudit(string table, string field, string strpk, int idpk, int userid);
    }
    public class AuditableRepository : IAuditableRepository
    {
        private readonly string connectionString;

        public AuditableRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public Task<bool> Audit(string table, string field, string strpk, int idpk, int userid)
        {
            throw new NotImplementedException();
        }


        //parametros tabla y id de la pk de la tabla. se pondra fecha de hoy y id de usuario que se pase por parametro.
        //siempre es un update
        public async Task<bool> UpdateAudit(string table, string field, string pk_name, int pk_id_num, int userid)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                var result = await conn.ExecuteAsync(@"
                    UPDATE @table
                    SET @field = GETDATE(), UpdatedBy = @userid
                    WHERE @strpk = @idpk", new { table, field, pk_name, pk_id_num, userid });
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar operacion de auditoria: " + ex.Message);
            }
            return false;
        }
    }
}