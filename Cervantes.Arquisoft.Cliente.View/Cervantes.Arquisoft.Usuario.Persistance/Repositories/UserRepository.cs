using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly string connectionString;

        public UserRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Create(UserDto userDto)
        {
            userDto.UserStateId = 1;

            try
            {
                using var conn = new SqlConnection(connectionString);
                userDto.Password = userDto.DocumentNumber.ToString();
                var id = await conn.QuerySingleAsync<int>("INSERT INTO Users (Name,LastName,Password,DocumentNumber,Mail,Telephone,UserRoleId,UserStateId) " +
                    "VALUES (@Name, @LastName,@Password,@DocumentNumber,@Mail, @Telephone,@UserRoleId,@UserStateId); SELECT SCOPE_IDENTITY(); SELECT SCOPE_IDENTITY();", userDto);


                userDto.UserId = id;

                Console.WriteLine("Consulta Create: " + id);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta Create User: " + ex.Message);
            }
        }

        public async Task<bool> Exist(int dni)
        {
            using var conn = new SqlConnection(connectionString);
            var result = await conn.QueryFirstOrDefaultAsync<int>(@"SELECT 1 FROM Users WHERE DocumentNumber = @dni AND UserStateId = 1;", new { dni });
            return result == 1;
        }

        public async Task<IEnumerable<UserDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryAsync<UserDto>(@"SELECT * FROM Users 
                                                     where UserStateId = 1 and UserId != 1 
                                                     ORDER BY LastName ASC, NAME ASC;");
        }

        public async Task Update(UserDto userDto)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.ExecuteAsync(@"UPDATE Users SET Name = @Name, LastName = @LastName, DocumentNumber = @DocumentNumber,
                                                         Mail = @Mail, Telephone = @Telephone, UserRoleId = @UserRoleId WHERE UserId = @UserId", userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de inserción de la direccion del cliente: " + ex.Message);
            }
        }

        public async Task Delete(int id)
        {

            using var conn = new SqlConnection(connectionString);
            try
            {
                await conn.ExecuteAsync(@"
                UPDATE Users set UserStateId = 2 where UserId = @Id",
                    new { id }); // Actualizar el estado del cliente a "2" (eliminado)
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de inserción de la direccion del cliente: " + ex.Message);
            }
        }

        public async Task RoleChange(UserDto userDto)
        {
            try
            {
                using var conn = new SqlConnection(connectionString);
                await conn.ExecuteAsync(@"UPDATE Users SET UserRoleId = @UserRoleId WHERE UserId = @UserId", userDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar Role Change del Usuario: " + ex.Message);
            }
        }

        public async Task<UserDto> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            return await conn.QueryFirstOrDefaultAsync<UserDto>(@"SELECT * FROM Users WHERE UserId = @Id and UserStateId = 1", new { id });
        }


    }

}

